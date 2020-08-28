using UnityEngine;

// Bobs object up and down like a coin
public class CoinBobber : MonoBehaviour
{
    const float BOB_SPEED = 2;
    const float BOB_AMP = 0.15f;

    Vector2 startPos; // Starting position of object

    // Initializing variables
    private void Awake() { startPos = transform.position; }

    // Bobbing
    void Update() { transform.position = startPos + Vector2.up * Mathf.Sin(Time.time * BOB_SPEED) * BOB_AMP; }
}
