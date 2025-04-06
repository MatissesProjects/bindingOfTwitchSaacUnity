using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void Start()
    {
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

    private void OnAttackingPlayer(AttackingPlayer enemy)
    {
        Debug.Log("attacking player with damage " + enemy.Attacker.GetDamage());
        EventBus.Raise(new DamagePlayer(enemy.Attacker.GetDamage()));
    }
}