using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;

    [HideInInspector] public int teams, teamSize;

    private int winningTeam;
    private Color teamColor;
    [HideInInspector] public Scene currentScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1")
            PlayerManager.instance.initPlayers(teams, teamSize);

        if (scene.name == "Win Scene")
            WinScene.instance.SetWinText(winningTeam, teamColor);

        SettingsManager.Instance.LoadSettings();
    }

    public void LoadLevelScene(int level)
    {
        SceneManager.LoadScene("Level " + level);
    }

    public void LoadWinScene(int winningTeam, Color teamColor)
    {
        this.winningTeam = winningTeam;
        this.teamColor = teamColor;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Win Scene");
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
