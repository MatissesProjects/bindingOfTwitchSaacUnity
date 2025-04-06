using UnityEngine;

public class MaterialColorizerEnemy : MonoBehaviour
{
    private static readonly int DisplayColor = Shader.PropertyToID("_displayColor");
    private Material _shader;

    private void Start()
    {
        _shader = GetComponent<Renderer>().material;

        EventBus.Subscribe<PlayerFound>(OnPlayerFound);
        EventBus.Subscribe<PlayerLost>(OnPlayerLost);

        EventBus.Subscribe<CanAttackPlayer>(OnAttackingPlayer);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerFound>(OnPlayerFound);
        EventBus.Unsubscribe<PlayerLost>(OnPlayerLost);
        EventBus.Unsubscribe<CanAttackPlayer>(OnAttackingPlayer);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<PlayerFound>(OnPlayerFound);
        EventBus.Unsubscribe<PlayerLost>(OnPlayerLost);
        EventBus.Unsubscribe<CanAttackPlayer>(OnAttackingPlayer);
    }

    private void OnPlayerFound(PlayerFound player)
    {
        _shader.SetColor(DisplayColor, Color.green);
        Debug.Log("setting color to green - OnPlayerFound");
    }

    private void OnPlayerLost(PlayerLost player)
    {
        _shader.SetColor(DisplayColor, Color.blue);
        Debug.Log("setting color to blue - OnPlayerLost");
    }

    private void OnAttackingPlayer(CanAttackPlayer player)
    {
        _shader.SetColor(DisplayColor, Color.red);
        // Debug.Log("OnPlayerFound - setting color to red");
    }
}