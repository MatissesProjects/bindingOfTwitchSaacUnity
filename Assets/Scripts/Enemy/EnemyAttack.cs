using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void Start()
    {
        // TODO Subscribe to global event bus for state changes for colors
        EventBus.Subscribe<AttackingPlayer>(OnAttackingPlayer);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<AttackingPlayer>(OnAttackingPlayer);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<AttackingPlayer>(OnAttackingPlayer);
    }

    private void OnAttackingPlayer(AttackingPlayer player)
    {
        Debug.Log("attacking player");
        // TODO find out how much damage we do to the player
    }
}