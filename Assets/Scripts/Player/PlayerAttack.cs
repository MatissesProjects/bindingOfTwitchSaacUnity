using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private readonly List<Enemy> _enemies = new();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            // Debug.Log("adding an enemy");
            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            _enemies.Remove(enemy);
    }

    private void OnCanAttackEnemy(CanAttackEnemy enemy)
    {
        // check if we can attack player yet, if the cooldown has passed
        if (!_player.CanAttack()) return;
        Debug.Log(_player.name + " is attacking player with damage " + _player.GetDamage());
        // TODO sort the enemies list by distance? or we aim at them or somethin
        if (_enemies.Count == 0) return;
        EventBus.Raise(new DamageEnemy(_enemies[0], _player.GetDamage()));
        _player.SetNextAttackTime();
    }
}