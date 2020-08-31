using TMPro;
using UnityEngine;

// Controls deaths text
[RequireComponent(typeof(TextMeshProUGUI))]
public class DeathsText : MonoBehaviour
{
    TextMeshProUGUI deathsText;

    // Initializing variables
    public void Awake() { deathsText = GetComponent<TextMeshProUGUI>(); }

    // Set-up
    public void Start() { UpdateCounter(); }

    // Adds death to global total and updates counter
    public void AddDeath()
    {
        GlobalVariables.numDeaths++;
        UpdateCounter();
    }

    // Updates counter with global variables count
    public void UpdateCounter()
    {
        switch (GlobalVariables.numDeaths)
        {
            case 0:
                deathsText.text = "";
                break;
            case 1:
                deathsText.text = GlobalVariables.numDeaths + " <b>Death</b>";
                break;
            default:
                deathsText.text = GlobalVariables.numDeaths + " <b>Deaths</b>";
                break;
        }
    }
}
