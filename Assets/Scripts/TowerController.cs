using UnityEngine;

public class TowerController : CharactorBase
{
    [SerializeField] private GameSystem gameSystem;
    [SerializeField] private int maxTowerHP = 100;

    private bool isGameOverTriggered = false;

    private HealthBar hpBar;  // HealthBar�Q��

    void Start()
    {
        SetParameter(maxTowerHP, maxTowerHP, 0, 0f, 0f);

        // �q�I�u�W�F�N�g��HealthBar������Ȃ�擾
        hpBar = GetComponentInChildren<HealthBar>();
        if (hpBar != null)
        {
            hpBar.SetHealth(1f);  // �ő�HP��ԂɍX�V
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
            Debug.Log("�G���^���[�ɏՓˁI");

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
