using UnityEngine;

public class CharactorBase : MonoBehaviour
{
    protected CharactorParameter _charactorParamater;

    public bool IsDead => _charactorParamater != null && _charactorParamater.GetCurrentHp <= 0;


    protected virtual void SetParameter(int currentHp, int maxHp, int attack, float moveSpeed, float range)
    {
        _charactorParamater = new CharactorParameter(currentHp, maxHp, attack, moveSpeed, range);
    }

    public void DamageBehaviour(int damage)
    {
        _charactorParamater.SetHp(_charactorParamater.GetCurrentHp - damage);
        Debug.Log($"{gameObject.name} took {damage} damage! Current HP: {_charactorParamater.GetCurrentHp}");
    }

    protected virtual void OnDead()
    {
        Debug.Log($"{gameObject.name} died.");
    }
}
