using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    const float DELAY_UNTIL_RESTART = 0.5f;

    public Sound explosionSound;

    // Initializing variables
    void Awake()
    {
        explosionSound.audioSource = gameObject.AddComponent<AudioSource>();
        explosionSound.audioSource.clip = explosionSound.audioClip;
        explosionSound.audioSource.volume = explosionSound.volume;
    }

    /* Starts explosion animation
     * @param lengthOfExplosion how long to show explosion on screen for
     */
    public void StartExplosion(float lengthOfExplosion)
    {
        explosionSound.audioSource.Play();
        StartCoroutine(ShowExplosion(lengthOfExplosion));
    }

    /* Shows explosion and then restarts
     * @param lengthOfExplosion how long to show explosion on screen for
     */
    IEnumerator ShowExplosion(float lengthOfExplosion)
    {
        yield return new WaitForSecondsRealtime(lengthOfExplosion);
        GetComponent<SpriteRenderer>().sprite = null;
        yield return new WaitForSecondsRealtime(DELAY_UNTIL_RESTART);
        GlobalVariables.coinsFound = 0;
        FindObjectOfType<NextSceneFader>().Restart();
    }
}
