using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [Header("Random Movement Settings")]
    public float moveSpeed = 2f;          // Movement speed
    public float minX = -7f;            // Bounds for random movement
    public float maxX = 7f;
    public float minY = -3f;
    public float maxY = 3f;
    public float closeEnoughDistance = 1f;
    public float stopDistance = 1.5f;
    
    private Rigidbody2D _rb;
    private PlayerMovement _player;
    private Vector2 _randomDestination;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        PickRandomDestination(); // Pick an initial random location
    }

    private void FixedUpdate()
    {
        if (_player == null)
        {
            // Debug.Log("WanderRandomly");
            WanderRandomly();
        }
        else
        {
            Debug.Log("ChasePlayer");
            ChasePlayer();
        }
    }

    private void WanderRandomly()
    {
        if (Vector2.Distance(_rb.position, _randomDestination) < closeEnoughDistance)
        {
            PickRandomDestination();
        }

        Vector2 direction = (_randomDestination - _rb.position).normalized;
        Vector2 newPosition = _rb.position + direction * (moveSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(newPosition);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.MoveRotation(angle);
    }

    private void ChasePlayer()
    {
        Vector2 targetPos = _player.transform.position;
        Vector2 currentPos = _rb.position;
        float distance = Vector2.Distance(currentPos, targetPos);
        // Debug.Log(distance);
        if (distance > stopDistance)
        {
            Vector2 direction = (targetPos - currentPos).normalized;
            Vector2 newPosition = currentPos + direction * (moveSpeed * Time.fixedDeltaTime);
            _rb.MovePosition(newPosition);

            // TODO Optional fix rotation to face the player - currently bounces to much
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            // _rb.MoveRotation(angle);
            _rb.MoveRotation(angle);
        }
        else
        {
            // TODO attack?
            Debug.Log("attacking time?");
            EventBus.Raise(new AttackingPlayer());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.GetComponent<PlayerMovement>();
            EventBus.Raise(new PlayerFound());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = null;
            EventBus.Raise(new PlayerLost());
        }
    }

    private void PickRandomDestination()
    {
        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);
        _randomDestination = new Vector2(randX, randY);
        Debug.Log("new random location "+ _randomDestination);
    }
}
