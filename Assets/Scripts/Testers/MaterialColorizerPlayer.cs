using System;
using UnityEngine;

public class MaterialColorizerPlayer : MonoBehaviour
{
    private static readonly int DisplayColor = Shader.PropertyToID("_displayColor");
    private Material _shader;

    private void Start()
    {
        _shader = GetComponent<Renderer>().material;
        
        // TODO Subscribe to global event bus for state changes for colors
        EventBus.Subscribe<PlayerMoving>(OnPlayerMoving);
        EventBus.Subscribe<PlayerStoppedMoving>(OnPlayerStopMoving);
        
        EventBus.Subscribe<AttackingPlayer>(OnAttackingPlayer);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<PlayerMoving>(OnPlayerMoving);
        EventBus.Unsubscribe<PlayerStoppedMoving>(OnPlayerStopMoving);
        
        EventBus.Unsubscribe<AttackingPlayer>(OnAttackingPlayer);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerMoving>(OnPlayerMoving);
        EventBus.Unsubscribe<PlayerStoppedMoving>(OnPlayerStopMoving);
        
        EventBus.Unsubscribe<AttackingPlayer>(OnAttackingPlayer);
    }

    private void OnAttackingPlayer(AttackingPlayer player)
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
