using TMPro;
using UnityEngine;

// Controls coins text
[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinsText : MonoBehaviour
{
    TextMeshProUGUI coinsText;
    public Sound coinSound;

    // Initializing variables
    public void Awake()
    {
        coinsText = GetComponent<TextMeshProUGUI>();

        // Sounds
        coinSound.audioSource = gameObject.AddComponent<AudioSource>();
        coinSound.audioSource.clip = coinSound.audioClip;
        coinSound.audioSource.volume = coinSound.volume;
    }

    // Set-up
    public void Start() { UpdateCounter(); }

    // Adds coin to global total and updates counter
    public void AddCoin()
    {
        coinSound.audioSource.Play();
        GlobalVariables.coinsFound++;
        UpdateCounter();
    }

    // Updates counter with global variables count
    public void UpdateCounter() { coinsText.text = "<b>Coins</b> " + GlobalVariables.coinsFound + "/" + GlobalVariables.maxCoins; }
}
