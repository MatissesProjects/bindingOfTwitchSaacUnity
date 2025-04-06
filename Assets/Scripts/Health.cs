using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] //
    private float health, maxHealth;

    public void TakeDamage(float damage)
    {
        health -= damage;
        IsDead();
    }

    private bool IsDead()
    {
        if (!(health <= 0)) return false;
        Debug.Log(gameObject.name + " is ded");
        EventBus.Raise(new PlayerDead());
        return true;
    }
}