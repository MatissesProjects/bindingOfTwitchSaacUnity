public class EnemyDead
{
    public EnemyDead(Enemy attacker)
    {
        Attacker = attacker;
    }

    public Enemy Attacker { get; }
}

public class DamageEnemy
{
    public DamageEnemy(Enemy enemy, float damage)
    {
        Damage = damage;
        AttackingEnemy = enemy;
    }

    public float Damage { get; }
    public Enemy AttackingEnemy { get; }
}

public struct CanAttackEnemy
{
}