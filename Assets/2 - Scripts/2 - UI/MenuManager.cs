using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    [Header("References")]
    [SerializeField] private TMP_Dropdown teamDropdown;
    [SerializeField] private TMP_Dropdown playerDropdown;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject inGameUI;


    public void StartGame(int level)
    {
        SceneManagement.instance.teams = teamDropdown.value + 2;
        SceneManagement.instance.teamSize = playerDropdown.value + 1;
        SceneManagement.instance.LoadLevelScene(level);
    }

    public void LoadSettingsScene()
    {
        SceneManagement.instance.LoadSettingsScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManagement.instance.LoadMenuScene();
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        inGameUI.SetActive(false);

        Time.timeScale = 0;
        GameManager.instance.DeactivateCurrentPlayer();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        inGameUI.SetActive(true);

        Time.timeScale = 1;
        GameManager.instance.ActivateCurrentPlayer();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SettingsManager.Instance.LoadSettings();
    }

    public void SettingsMenu()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    private void Update()
    {
        if (SceneManagement.instance.currentScene.name == "Level 1" && Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseMenu();
            }
        }
    }
}
