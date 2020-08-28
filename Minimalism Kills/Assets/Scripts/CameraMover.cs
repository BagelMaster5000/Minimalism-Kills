using UnityEngine;

public class CameraMover : MonoBehaviour
{
    // Variables that can be altered in inspector
    [SerializeField] private float camSmoothness = 5;
    [SerializeField] private float distanceAbovePlayer = 1.5f;

    // Variables assigned in-script
    Transform playerTransform;
    float distanceBack = -10;

    // Used for cutscenes
    bool onPlayer = true;
    Transform otherObject;

    // Initializing variables
    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        distanceBack = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTransform != null && onPlayer)
            transform.position = new Vector3(
                Mathf.SmoothStep(transform.position.x, playerTransform.position.x, 1 / camSmoothness),
                Mathf.SmoothStep(transform.position.y, playerTransform.position.y + distanceAbovePlayer, 1 / camSmoothness),
                distanceBack);
    }
}
