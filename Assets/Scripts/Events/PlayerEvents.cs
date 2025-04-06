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

// happening to player
public class AttackingPlayer
{
    public AttackingPlayer(Enemy attacker)
    {
        Attacker = attacker;
    }

    public Enemy Attacker { get; private set; }
}