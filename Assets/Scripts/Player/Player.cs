using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        EventBus.Subscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Subscribe<PlayerDead>(OnPlayerDead);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Unsubscribe<PlayerDead>(OnPlayerDead);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Unsubscribe<PlayerDead>(OnPlayerDead);
    }

    private void OnPlayerDead(PlayerDead damagePlayer)
    {
        // TODO show some restart menu
        Debug.Log("oh no you deaded");
    }

    private void OnDamagePlayer(DamagePlayer damagePlayer)
    {
        GetComponent<Health>().TakeDamage(damagePlayer.Damage);
    }
}