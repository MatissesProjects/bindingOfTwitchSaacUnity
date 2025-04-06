using UnityEngine;

public class Player : Character
{
    [SerializeField] //
    private float speed, baseAttackDamage, attackCooldown;

    private float _nextAttackTime;

    private void Start()
    {
        EventBus.Subscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Subscribe<IncreasePlayerHealth>(OnIncreasePlayerHealth);
        EventBus.Subscribe<PlayerDead>(OnPlayerDead);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Unsubscribe<IncreasePlayerHealth>(OnIncreasePlayerHealth);
        EventBus.Unsubscribe<PlayerDead>(OnPlayerDead);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Unsubscribe<IncreasePlayerHealth>(OnIncreasePlayerHealth);
        EventBus.Unsubscribe<PlayerDead>(OnPlayerDead);
    }

    private void OnPlayerDead(PlayerDead damagePlayer)
    {
        // TODO show some restart menu
        Debug.Log("oh no you deaded");
    }

    private void OnDamagePlayer(DamagePlayer damagePlayer)
    {
        GetComponent<Health>().TakeDamage(damagePlayer.Damage);
    }

    private void OnIncreasePlayerHealth(IncreasePlayerHealth _)
    {
        GetComponent<Health>().HealOne();
    }

    public float GetDamage()
    {
        return baseAttackDamage;
    }

    public bool CanAttack()
    {
        return Time.time >= _nextAttackTime;
    }

    public void SetNextAttackTime()
    {
        _nextAttackTime = Time.time + attackCooldown;
    }
}