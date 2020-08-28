using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using System.Collections;
using UnityEngine.Events;

public class Dialogger : MonoBehaviour
{
    const float TEXT_DISPLAY_SPEED = 0.02f;
    const int TEXT_SCALE_START_DELTA = -10;
    const int TALKING_SOUND_DELAY = 5;

    [Header("Story")]
    public TextAsset[] monologueFiles;
    static Story[] stories;
    int curStoryIndex;

    [Header("UI")]
    public TextMeshProUGUI message; //Dialog displaying text

    //Text appearing
    bool canContinue = true;
    float startTextSize;
    bool madeDecision = true;

    [Header("Sounds")]
    public Sound talkingSound;

    // Inputs
    InputMaster inputs;
    bool fastForward;

    // Visuals to show+hide
    public UnityEvent startDialogEvents;
    public UnityEvent endDialogEvents;

    #region Input and Sounds Setup

    // Initialize variables
    private void Awake()
    {
        inputs = new InputMaster();
        inputs.Text.Advance.performed += ctx => ContinueStory();
        inputs.Enable();

        talkingSound.audioSource = gameObject.AddComponent<AudioSource>();
        talkingSound.audioSource.clip = talkingSound.audioClip;
        talkingSound.audioSource.volume = talkingSound.volume;
    }

    // Disables inputs when object is set inactive
    private void OnDisable() { inputs.Disable(); }

    #endregion

    // General Set-up
    void Start()
    {
        startTextSize = message.fontSize;
        stories = new Story[monologueFiles.Length];
        for (int s = 0; s < monologueFiles.Length; s++)
            stories[s] = new Story(monologueFiles[s].text);
        startDialogEvents.Invoke();
        ContinueStory();
    }

    public void StartDialog(int storyIndex)
    {
        curStoryIndex = storyIndex;
        startDialogEvents.Invoke();
        ContinueStory();
    }

    // Advances dialog if able; otherwise, ends story
    public void ContinueStory()
    {
        if (stories[curStoryIndex].canContinue && canContinue)
            AdvanceDialog();
        else if (stories[curStoryIndex].canContinue && !canContinue)
            fastForward = true;
        else if (madeDecision && canContinue)
            FinishDialog();
    }

    // Advances dialog
    void AdvanceDialog()
    {
        string curSentence = stories[curStoryIndex].Continue();
        StartCoroutine(ShowDialog(curSentence));
    }

    // Closes dialog when done
    void FinishDialog()
    {
        endDialogEvents.Invoke();
    }

    /* Shows dialog character-by-character
     * @param sentence segment of dialog to display
     */
    IEnumerator ShowDialog(string sentence)
    {
        canContinue = false;
        List<float> letterSizes = new List<float>();

        talkingSound.audioSource.Play();
        int soundCounter = 0;
        
        //Printing text
        for (int index = 0; index < sentence.Length; index++)
        {
            letterSizes.Add(startTextSize + TEXT_SCALE_START_DELTA);
            message.text = "";
            for (int letNum = 0; letNum < letterSizes.Count; letNum++)
            {
                message.text += "<size=" + letterSizes[letNum] + ">" + sentence.Substring(letNum, 1) + "</size>";
                letterSizes[letNum] = Mathf.SmoothStep(letterSizes[letNum], startTextSize, 0.5f);
            }
            soundCounter++;
            if (soundCounter > TALKING_SOUND_DELAY)
            {
                soundCounter = 0;
                talkingSound.audioSource.Play();
            }
            if (fastForward)
            {
                message.text = "<size=" + startTextSize + ">" + sentence + "</size>";
                break;
            }
            yield return new WaitForSecondsRealtime(TEXT_DISPLAY_SPEED);
        }

        //Shrinking text after all text has been displayed
        while (!fastForward && letterSizes[sentence.Length - 1] < startTextSize - 1)
        {
            message.text = "";
            for (int letNum = 0; letNum < letterSizes.Count; letNum++)
            {
                message.text += "<size=" + letterSizes[letNum] + ">" + sentence.Substring(letNum, 1) + "</size>";
                letterSizes[letNum] = Mathf.SmoothStep(letterSizes[letNum], startTextSize, 0.5f);
            }
            yield return new WaitForSecondsRealtime(TEXT_DISPLAY_SPEED);
        }
        message.text = "<size=" + startTextSize + ">" + sentence + "</size>";

        fastForward = false;
        canContinue = true;

        print("Done");
    }
}
