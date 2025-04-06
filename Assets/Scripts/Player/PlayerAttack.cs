using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        EventBus.Subscribe<CanAttackEnemy>(OnCanAttackEnemy);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<CanAttackEnemy>(OnCanAttackEnemy);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<CanAttackEnemy>(OnCanAttackEnemy);
    }

    private void OnCanAttackEnemy(CanAttackEnemy enemy)
    {
        // check if we can attack player yet, if the cooldown has passed
        if (!_player.CanAttack()) return;
        Debug.Log(_player.name + " is attacking player with damage " + _player.GetDamage());
        EventBus.Raise(new DamageEnemy(_player.GetDamage()));
        _player.SetNextAttackTime();
    }
}