using TMPro;
using UnityEngine;

// Controls for title screen buttons
public class EndAnimator : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI deaths;
    public TextMeshProUGUI time;

    private void Start()
    {
        coins.text = "<b>Coins</b> " + GlobalVariables.coinsFound + "/" + GlobalVariables.maxCoins;
        deaths.text = "<b>Deaths</b> " + GlobalVariables.numDeaths;
        time.text = "<b>Time</b> " + GlobalVariables.numMins + "m " + GlobalVariables.numSecs + "s";
    }

    public void BackToTitle()
    {
        GlobalVariables.coinsFound = 0;
        GlobalVariables.numDeaths = 0;
        GlobalVariables.numMins = 0;
        GlobalVariables.numSecs = 0;
        FindObjectOfType<NextSceneFader>().FadeToNextScene("Title", true);
    }
}
