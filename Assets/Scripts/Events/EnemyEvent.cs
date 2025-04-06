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
    public DamageEnemy(float damage)
    {
        Damage = damage;
    }

    public float Damage { get; }
}

public struct CanAttackEnemy
{
}