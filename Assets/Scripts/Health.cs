using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] //
    private float health, maxHealth;

    public void TakeDamage(float damage)
    {
        health -= damage;
        CheckIsDead();
    }

    private void CheckIsDead()
    {
        if (health > 0) return;
        Debug.Log(gameObject.name + " is ded");
        if (TryGetComponent(out Player p))
            EventBus.Raise(new PlayerDead());
        if (TryGetComponent(out Enemy enemy))
            EventBus.Raise(new EnemyDead(enemy));
    }
}