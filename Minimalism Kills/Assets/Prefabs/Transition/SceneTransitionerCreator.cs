using UnityEngine;

// Creates a transition object if it doesn't already exist
public class SceneTransitionerCreator : MonoBehaviour
{
    [SerializeField] private GameObject sceneTransitioner; // Transition object prefab

    // Creating transition object if it doesn't already exist
    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("SceneTransitioner") == null)
            Instantiate(sceneTransitioner);
        Destroy(this);
    }
}
