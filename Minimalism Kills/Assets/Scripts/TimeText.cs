using System.Collections;
using TMPro;
using UnityEngine;

// Controls coins text
[RequireComponent(typeof(TextMeshProUGUI))]
public class TimeText : MonoBehaviour
{
    TextMeshProUGUI timeText;

    bool disabled;

    // Initializing variables
    public void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    // Set-up
    public void Start() { StartCoroutine(TimeTicker()); }

    // Sets disabled status
    public void SetDisabled(bool disabled) { this.disabled = disabled; }

    // Counts and updates text
    IEnumerator TimeTicker()
    {
        while (true)
        {
            timeText.text = "<b>Time</b> " + GlobalVariables.numMins + "m " + GlobalVariables.numSecs + "s";
            yield return new WaitForSecondsRealtime(1);
            if (!disabled)
            {
                GlobalVariables.numSecs++;
                if (GlobalVariables.numSecs >= 60)
                {
                    GlobalVariables.numSecs -= 60;
                    GlobalVariables.numMins++;
                }
            }
        }
    }
}
