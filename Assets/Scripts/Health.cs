using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] //
    private float health;

    private float maxHealth;

    private void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        CheckIsDead();
    }

    [ContextMenu("Take 1 Damage")]
    public void Take1Damage()
    {
        EventBus.Raise(new DamagePlayer(1));
    }

    public void SetMaxHealth(float h)
    {
        maxHealth = h;
        health = h;
    }

    public float GetCurrentHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
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