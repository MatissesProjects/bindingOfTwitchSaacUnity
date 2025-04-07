using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 _movement;
    private Rigidbody2D rb;
    private bool triggeredStopMoved, triggeredPlayerMoved;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Capture input
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1")) EventBus.Raise(new CanAttackEnemy());
    }

    private void FixedUpdate()
    {
        // Move the player
        if (_movement.magnitude > 0)
        {
            rb.MovePosition(rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
            if (!triggeredPlayerMoved)
            {
                EventBus.Raise(new PlayerMoving());
                triggeredPlayerMoved = true;
            }

            triggeredStopMoved = false;
        }
        else if (!triggeredStopMoved)
        {
            EventBus.Raise(new PlayerStoppedMoving());
            triggeredStopMoved = true;
            triggeredPlayerMoved = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.name);
        if (other.gameObject.name.Contains("Door")) EventBus.Raise(new PlayerTouchedDoor(other.gameObject));
    }
}