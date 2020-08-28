using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public Sound music; //BG Music
    public Sound transitionSound; //Sound played when scene transition starts
    float fadeOutFactor = 50; // Higher means slower fade out

    static MusicManager instance;

    //Instantiates variables
    private void Awake()
    {
        //Destroys object if another one has been carried over from the previous scene
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        music.audioSource = gameObject.AddComponent<AudioSource>();
        music.audioSource.clip = music.audioClip;
        music.audioSource.volume = music.volume;
        music.audioSource.loop = true;
        music.audioSource.Play();

        transitionSound.audioSource = gameObject.AddComponent<AudioSource>();
        transitionSound.audioSource.clip = transitionSound.audioClip;
        transitionSound.audioSource.volume = transitionSound.volume;
    }

    //Stops music
    public void StopMusic()
    {
        //transitionSound.audioSource.Play();
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        StartCoroutine(FadeOut());
    }

    /*Returns AudioSource component of music
     *@return AudioSource component of music
     */
    public AudioSource GetMusic() { return music.audioSource; }

    //Fades out music
    IEnumerator FadeOut()
    {
        while (music.audioSource.volume > 0)
        {
            music.audioSource.volume = Mathf.Lerp(music.audioSource.volume, 0, 1 / fadeOutFactor);
            yield return null;
        }
    }
}
