using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 _movement;
    private bool triggeredStopMoved, triggeredPlayerMoved;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Capture input
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
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
    }
}