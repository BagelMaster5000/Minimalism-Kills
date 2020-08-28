using UnityEngine;
using UnityEngine.Events;

// Calls event when triggered
public class TriggerEvent : MonoBehaviour
{
    public UnityEvent triggerEvent;
    bool disabled;

    // Calls event when triggered
    private void OnTriggerEnter2D(Collider2D collision) { if (!disabled) triggerEvent.Invoke(); }

    // Disables triggering
    public void Disable() { disabled = true; }
}
