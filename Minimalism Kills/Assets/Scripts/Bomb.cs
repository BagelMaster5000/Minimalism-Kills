using UnityEngine;
using UnityEngine.Events;

// Bomb that player must avoid
[RequireComponent(typeof(BoxCollider2D))]
public class Bomb : MonoBehaviour
{
    // Kills player when touches bomb
    private void OnTriggerEnter2D(Collider2D collision) { FindObjectOfType<PlayerController>().Kill(); }
}

