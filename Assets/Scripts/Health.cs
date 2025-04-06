using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] //
    private float health, maxHealth;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}