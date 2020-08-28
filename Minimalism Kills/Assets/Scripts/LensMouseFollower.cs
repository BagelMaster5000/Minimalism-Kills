using UnityEngine;
using UnityEngine.InputSystem;

// Lens follows mouse position. Don't use if using only keyboard controls
public class LensMouseFollower : MonoBehaviour
{
    public Camera cam;

    //Detaches from player
    private void Start() { transform.parent = null; }

    //Sets position
    void Update() { transform.position = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()) + Vector3.forward * 10; }
}
