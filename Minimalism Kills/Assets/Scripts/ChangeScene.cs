using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName) { FindObjectOfType<NextSceneFader>().FadeToNextScene(sceneName, false); }
}
