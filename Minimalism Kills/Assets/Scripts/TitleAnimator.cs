using UnityEngine;

// Controls for title screen buttons
public class TitleAnimator : MonoBehaviour
{
    public void StartGame() { FindObjectOfType<NextSceneFader>().FadeToNextScene("Level", true); }

    public void ExitGame() { Application.Quit(); }
}
