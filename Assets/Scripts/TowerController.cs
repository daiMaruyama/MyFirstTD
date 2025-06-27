using UnityEngine;

public class TowerController : CharactorBase
{
    [SerializeField] private GameSystem gameSystem;
    [SerializeField] private int maxTowerHP = 100;

    private bool isGameOverTriggered = false;

    private HealthBar hpBar;  // HealthBar参照

    void Start()
    {
        SetParameter(maxTowerHP, maxTowerHP, 0, 0f, 0f);

        // 子オブジェクトにHealthBarがあるなら取得
        hpBar = GetComponentInChildren<HealthBar>();
        if (hpBar != null)
        {
            hpBar.SetHealth(1f);  // 最大HP状態に更新
        }
    }

    void Update()
    {
        if (_charactorParamater == null) return;

        if (IsDead && !isGameOverTriggered)
        {
            gameSystem.SetIsGameover(true);
            isGameOverTriggered = true;
            Debug.Log("Game Over: Tower destroyed!");
            OnDead();
        }

        if (hpBar != null && _charactorParamater != null)
        {
            float hpRate = (float)_charactorParamater.GetCurrentHp / _charactorParamater.GetMaxHp;
            hpBar.SetHealth(hpRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("敵がタワーに衝突！");

            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                DamageBehaviour(enemy.AttackPower);
            }

            Destroy(collision.gameObject);
        }
    }

    public void RestoreHP(int amount)
    {
        int newHP = Mathf.Min(_charactorParamater.GetCurrentHp + amount, _charactorParamater.GetMaxHp);
        _charactorParamater.SetHp(newHP);
    }
}
