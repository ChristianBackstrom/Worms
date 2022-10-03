using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManagement.instance.currentScene.name == "Level 1")
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
