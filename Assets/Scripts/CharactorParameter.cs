using UnityEngine;

public class CharactorParameter
{
    private int currentHp;
    private int maxHp;
    private int attack;
    private float moveSpeed;
    private float range;

    public int GetCurrentHp => currentHp;
    public int GetMaxHp => maxHp;
    public int GetAttack => attack;
    public float GetMoveSpeed => moveSpeed;
    public float GetRange => range;

    public CharactorParameter(int currentHp, int maxHp, int attack, float moveSpeed, float range)
    {
        this.currentHp = currentHp;
        this.maxHp = maxHp;
        this.attack = attack;
        this.moveSpeed = moveSpeed;
        this.range = range;
    }

    public void SetHp(int newHp)
    {
        currentHp = Mathf.Clamp(newHp, 0, maxHp);
    }
}

