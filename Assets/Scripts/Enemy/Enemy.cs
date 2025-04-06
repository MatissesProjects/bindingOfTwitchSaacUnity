using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] //
    private float _speed, _baseAttackDamage, _attackCooldown;

    public float GetDamage()
    {
        return _baseAttackDamage;
    }

    public float GetAttackCooldown()
    {
        return _attackCooldown;
    }
}