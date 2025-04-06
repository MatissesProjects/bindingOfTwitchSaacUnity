// happening by player

public struct PlayerFound
{
}

public struct PlayerLost
{
}

public struct PlayerMoving
{
}

public struct PlayerStoppedMoving
{
}

public struct PlayerDead
{
}

// happening to player
public class CanAttackPlayer
{
    public CanAttackPlayer(Enemy attacker)
    {
        Attacker = attacker;
    }

    public Enemy Attacker { get; }
}

public class DamagePlayer
{
    public DamagePlayer(float damage)
    {
        Damage = damage;
    }

    public float Damage { get; }
}