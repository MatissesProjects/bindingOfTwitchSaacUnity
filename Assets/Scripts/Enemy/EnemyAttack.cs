using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void Start()
    {
        EventBus.Subscribe<CanAttackPlayer>(OnCanAttackPlayer);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<CanAttackPlayer>(OnCanAttackPlayer);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<CanAttackPlayer>(OnCanAttackPlayer);
    }

    private void OnCanAttackPlayer(CanAttackPlayer enemy)
    {
        // check if we can attack player yet, if the cooldown has passed
        if (!enemy.Attacker.CanAttack()) return;
        Debug.Log(enemy.Attacker.name + " is attacking player with damage " + enemy.Attacker.GetDamage());
        EventBus.Raise(new DamagePlayer(enemy.Attacker.GetDamage()));
        enemy.Attacker.SetNextAttackTime();
    }
}