using UnityEngine;
using UnityEngine.SceneManagement;

// Controls transitioning between scenes
public class NextSceneFader : MonoBehaviour
{
    string nextScene;
    AudioSource transitionSound;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectOfType<MusicManager>() != null)
            transitionSound = FindObjectOfType<MusicManager>().transitionSound.audioSource;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Runs when scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (FindObjectOfType<MusicManager>() != null)
            transitionSound = FindObjectOfType<MusicManager>().transitionSound.audioSource;
    }

    //Plays transition sound
    void PlayTransitionSound()
    {
        if (transitionSound != null)
            transitionSound.Play();
    }

    /*Starts fade to next scene
     *@param nextScene name of next scene to load
     *@param stopMusic whether or not background music should fade out
     */
    public void FadeToNextScene(string nextScene, bool stopMusic)
    {
        PlayTransitionSound();

        //Stops BG music
        if (stopMusic)
            FindObjectOfType<MusicManager>().StopMusic();

        //Starts transition animation
        this.nextScene = nextScene;
        GetComponent<Animator>().SetBool("Dark", true);
    }

    /*Starts fade to next scene in scene hierarchy
     *@param stopMusic whether or not background music should fade out
     */
    public void FadeToNextScene(bool stopMusic)
    {
        PlayTransitionSound();

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            FadeToNextScene(SceneManager.GetActiveScene().name, false);
            return;
        }

        if (stopMusic)
            FindObjectOfType<MusicManager>().StopMusic();

        //Below code is stolen from Giora-Guttsait. Thank you and incredibly dumb that this is how you get the scene name of the next scene.
        string path = SceneUtility.GetScenePathByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        this.nextScene = name.Substring(0, dot);

        GetComponent<Animator>().SetBool("Dark", true);
    }

    //Restarts scene
    public void Restart()
    {
        PlayTransitionSound();

        this.nextScene = SceneManager.GetActiveScene().name;
        GetComponent<Animator>().SetBool("Dark", true);
    }

    //Executes scene load
    public void Load()
    {
        //if (nextScene != null)
        GetComponent<Animator>().SetBool("Dark", false);
        SceneManager.LoadScene(nextScene);
    }
}
