using UnityEngine;

public class MaterialColorizerPlayer : MonoBehaviour
{
    private static readonly int DisplayColor = Shader.PropertyToID("_displayColor");
    private Material _shader;

    private void Start()
    {
        _shader = GetComponent<Renderer>().material;

        EventBus.Subscribe<PlayerMoving>(OnPlayerMoving);
        EventBus.Subscribe<PlayerStoppedMoving>(OnPlayerStopMoving);

        EventBus.Subscribe<CanAttackPlayer>(OnAttackingPlayer);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerMoving>(OnPlayerMoving);
        EventBus.Unsubscribe<PlayerStoppedMoving>(OnPlayerStopMoving);

        EventBus.Unsubscribe<CanAttackPlayer>(OnAttackingPlayer);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<PlayerMoving>(OnPlayerMoving);
        EventBus.Unsubscribe<PlayerStoppedMoving>(OnPlayerStopMoving);

        EventBus.Unsubscribe<CanAttackPlayer>(OnAttackingPlayer);
    }

    private void OnAttackingPlayer(CanAttackPlayer player)
    {
        _shader.SetColor(DisplayColor, Color.red);
        // Debug.Log("OnPlayerFound - setting color to red");
    }

    private void OnPlayerMoving(PlayerMoving player)
    {
        _shader.SetColor(DisplayColor, Color.yellow);
    }

    private void OnPlayerStopMoving(PlayerStoppedMoving player)
    {
        _shader.SetColor(DisplayColor, Color.cyan);
    }
}