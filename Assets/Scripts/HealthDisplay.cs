using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // private Player _player;
    public GameObject healthPrefab;
    public List<GameObject> healthImages;

    private Player _player;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        var health = GetComponentInParent<Health>().GetCurrentHealth();
        Debug.Log("current health " + health);
        for (var i = 0; i < health; i++)
            healthImages.Add(Instantiate(healthPrefab, transform.position, Quaternion.identity, transform));
        EventBus.Subscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Subscribe<IncreasePlayerHealth>(OnIncreasePlayerHealth);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Unsubscribe<IncreasePlayerHealth>(OnIncreasePlayerHealth);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<DamagePlayer>(OnDamagePlayer);
        EventBus.Unsubscribe<IncreasePlayerHealth>(OnIncreasePlayerHealth);
    }

    private void OnIncreasePlayerHealth(IncreasePlayerHealth _)
    {
        var healthData = GetComponentInParent<Health>();
        // healthData.TakeDamage(damagePlayer.Damage);
        var index = (int)Mathf.Clamp(healthData.GetMaxHealth() - healthData.GetCurrentHealth(), 1,
            healthData.GetMaxHealth() - 1) - 1;
        Debug.Log(index);
        healthImages[index].GetComponent<Image>().color = Color.red;
    }

    private void OnDamagePlayer(DamagePlayer damagePlayer)
    {
        var healthData = GetComponentInParent<Health>();
        // healthData.TakeDamage(damagePlayer.Damage);
        var index = (int)Mathf.Clamp(healthData.GetMaxHealth() - healthData.GetCurrentHealth(), 0,
            healthData.GetMaxHealth() - 1);
        Debug.Log(index);
        healthImages[index].GetComponent<Image>().color = Color.grey;
    }
}