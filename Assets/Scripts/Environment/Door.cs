using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    public Room targetRoom;

    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        print("started");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (targetRoom) print("door now");
        // RoomManager.Instance.SetActiveRoom(targetRoom);
        // other.transform.position = targetRoom.spawnPoint; // GetSpawnPosition or we
    }
}