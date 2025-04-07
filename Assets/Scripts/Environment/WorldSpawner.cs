using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity, transform);
    }
}