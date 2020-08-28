using UnityEngine;
using UnityEngine.Events;

// Coin pickup that player can collect
[RequireComponent(typeof(BoxCollider2D))]
public class CoinPickup : MonoBehaviour
{
    public UnityEvent coinPickupEvent;

    // Collects coin when player touches coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Shows particle effect
        GameObject particles = GetComponentInChildren<ParticlesDetachAndDestroy>().gameObject;
        if (particles != null)
            particles.GetComponent<ParticlesDetachAndDestroy>().Activate();

        // Coin event
        coinPickupEvent.Invoke();

        // Destroys coin
        Destroy(this.gameObject);
    }
}
