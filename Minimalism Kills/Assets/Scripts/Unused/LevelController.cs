using UnityEngine;

// Currently allows for player to reset level when dead
public class LevelController : MonoBehaviour
{
    InputMaster levelController;

    // Initializing inputs
    void Awake()
    {
        levelController = new InputMaster();
        levelController.GameController.ResetLevel.performed += ctx => ResetLevel();
        levelController.GameController.Enable();
    }

    // Disables inputs when object is disabled
    void OnDisable() { levelController.GameController.Disable(); }

    // Resets level if player is dead
    void ResetLevel()
    {
        if (FindObjectOfType<PlayerController>() == null)
        {
            GlobalVariables.coinsFound = 0;
            FindObjectOfType<NextSceneFader>().Restart();
        }
    }
}
