using System.Collections;
using UnityEngine;

public enum Animation
{
    LeftRightAnimation,
    UpDownAnimation,
    WiggleAnimation,
    CircleAnimation,
}

public class SpriteAnimation : MonoBehaviour
{
    public new Animation animation;
    
    [Header("Animation Settings")]
    public float moveDistance = 2f;  // How far left/right to move from its starting local position
    public float moveSpeed = 1f;     // Speed of the lerp
    
    float t;
    private Vector2 _startLocalPos;
    private bool _isPlayingAnimation;

    // Local positions for left and right relative to the parent
    Vector2 leftLocalPos;
    Vector2 rightLocalPos;
    Vector2 upLocalPos;
    Vector2 downLocalPos;

    void Start()
    {
        leftLocalPos = _startLocalPos - Vector2.right * moveDistance;
        rightLocalPos = _startLocalPos + Vector2.right * moveDistance;
        upLocalPos = _startLocalPos + Vector2.up * moveDistance;
        downLocalPos = _startLocalPos - Vector2.up * moveDistance;
    }

    public void Update()
    {
        // Store the starting local position (relative to the parent)
        _startLocalPos = transform.localPosition;
        // leftLocalPos = _startLocalPos - Vector2.right * moveDistance;
        // rightLocalPos = _startLocalPos + Vector2.right * moveDistance;
        // upLocalPos = _startLocalPos + Vector2.up * moveDistance;
        // downLocalPos = _startLocalPos - Vector2.up * moveDistance;
        
        // Debug.Log(animation);
        switch (animation)
        {
            case Animation.UpDownAnimation:
                _isPlayingAnimation = true;
                // PingPong will return a value between 0 and 1 that automatically
                // oscillates over time.
                t = Mathf.PingPong(Time.time * moveSpeed, 1f);

                // Lerp between left and right using that ping-ponging value.
                transform.localPosition = Vector2.Lerp(upLocalPos, downLocalPos, t);
                break;
            
            case Animation.LeftRightAnimation:
                _isPlayingAnimation = true;
                // PingPong will return a value between 0 and 1 that automatically
                // oscillates over time.
                t = Mathf.PingPong(Time.time * moveSpeed, 1f);

                // Lerp between left and right using that ping-ponging value.
                transform.localPosition = Vector2.Lerp(leftLocalPos, rightLocalPos, t);
                break;
            case Animation.WiggleAnimation:
                Debug.Log("doing a wiggle animation");
                break;
                
            case Animation.CircleAnimation:
                Debug.Log("doing a circle animation");
                break;
                
            default:
                Debug.Log("what is that? " + animation);
                break;
        }
    }
}
