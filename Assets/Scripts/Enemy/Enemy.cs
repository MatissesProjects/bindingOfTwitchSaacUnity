using UnityEngine;

public class Enemy : Character
{
    [SerializeField] //
    private float _speed, _baseAttackDamage, _attackCooldown;

    private float nextAttackTime;

    private void Start()
    {
        EventBus.Subscribe<DamageEnemy>(OnDamageEnemy);
        EventBus.Subscribe<EnemyDead>(OnEnemyDead);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<DamageEnemy>(OnDamageEnemy);
        EventBus.Unsubscribe<EnemyDead>(OnEnemyDead);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<DamageEnemy>(OnDamageEnemy);
        EventBus.Unsubscribe<EnemyDead>(OnEnemyDead);
    }

    private void OnDamageEnemy(DamageEnemy enemy)
    {
        GetComponent<Health>().TakeDamage(enemy.Damage);
    }

    private void OnEnemyDead(EnemyDead enemy)
    {
        Debug.Log("oh no you deaded " + enemy.Attacker.name);
        enemy.Attacker.gameObject.SetActive(false);
    }

    public float GetDamage()
    {
        return _baseAttackDamage;
    }

    public bool CanAttack()
    {
        return Time.time >= nextAttackTime;
    }

    public void SetNextAttackTime()
    {
        nextAttackTime = Time.time + _attackCooldown;
    }
}