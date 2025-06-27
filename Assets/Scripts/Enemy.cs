using UnityEngine;

public enum BulletType
{
    White,
    Green,
    Blue
}

public enum EnemyType
{
    White,
    Green,
    Blue,
    Gray
}

public class Enemy : CharactorBase
{
    [SerializeField] private int maxHp = 3;
    [SerializeField] private int attackPower = 10;
    [SerializeField] private EnemyType enemyType = EnemyType.White;

    public int AttackPower => attackPower;

    private int currentHp;
    private HealthBar hpBar;

    private void Start()
    {
        currentHp = maxHp;
        SetParameter(maxHp, maxHp, 1, 1f, 0f);

        if (TryGetComponentInChildren(out HealthBar healthBar))
        {
            hpBar = healthBar;
            hpBar.SetHealth(1f);
        }
    }

    private void Update()
    {
        GameSystem gs = FindObjectOfType<GameSystem>();
        if (gs != null && gs.IsGameOver()) return;

        if (IsDead)
        {
            OnDead();
            Destroy(gameObject);
            return;
        }

        if (hpBar != null)
        {
            hpBar.SetHealth((float)currentHp / maxHp);
        }
    }

    public void TakeDamage(BulletType bulletType)
    {
        GameSystem gs = FindObjectOfType<GameSystem>();
        if (gs != null && gs.IsGameOver()) return;

        if (enemyType != EnemyType.Gray && MatchesBullet(bulletType))
        {
            currentHp = 0;
        }
        else
        {
            currentHp--;
        }

        if (currentHp <= 0)
        {
            OnDead();
            Destroy(gameObject);
        }
    }

    private bool MatchesBullet(BulletType bulletType)
    {
        switch (enemyType)
        {
            case EnemyType.White: return bulletType == BulletType.White;
            case EnemyType.Blue: return bulletType == BulletType.Blue;
            case EnemyType.Green: return bulletType == BulletType.Green;
            default: return false;
        }
    }

    protected override void OnDead()
    {
        GameSystem gs = FindObjectOfType<GameSystem>();
        if (gs != null && !gs.IsGameOver())
        {
            gs.AddScore(100);
        }

        base.OnDead();
    }

    private bool TryGetComponentInChildren<T>(out T component) where T : Component
    {
        component = GetComponentInChildren<T>();
        return component != null;
    }
}
