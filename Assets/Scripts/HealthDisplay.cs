using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // private Player _player;
    public GameObject healthPrefab;
    public List<GameObject> healthImages;

    private void Start()
    {
        var health = GetComponentInParent<Health>().GetCurrentHealth();
        Debug.Log("current health " + health);
        for (var i = 0; i < health; i++)
            healthImages.Add(Instantiate(healthPrefab, transform.position, Quaternion.identity, transform));
        EventBus.Subscribe<DamagePlayer>(OnDamagePlayer);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<DamagePlayer>(OnDamagePlayer);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<DamagePlayer>(OnDamagePlayer);
    }

    private void OnDamagePlayer(DamagePlayer damagePlayer)
    {
        var healthData = GetComponentInParent<Health>();
        Debug.Log(healthData.GetCurrentHealth());
        Debug.Log(damagePlayer.Damage);
        Debug.Log(healthData.GetCurrentHealth() - damagePlayer.Damage);
        // healthData.TakeDamage(damagePlayer.Damage);
        var index = (int)(healthData.GetMaxHealth() - healthData.GetCurrentHealth());
        Debug.Log(index);
        Debug.Log(healthData.GetMaxHealth());
        healthImages[index].GetComponent<Image>().color = Color.grey;
    }
}