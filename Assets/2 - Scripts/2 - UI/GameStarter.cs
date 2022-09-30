using UnityEngine;
using TMPro;

public class GameStarter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Dropdown teamDropdown;
    [SerializeField] private TMP_Dropdown playerDropdown;


    public void StartGame(string Scene)
    {
        SceneManagement.instance.teams = teamDropdown.value + 2;
        SceneManagement.instance.teamSize = playerDropdown.value + 1;
        SceneManagement.instance.LoadScene(Scene);
    }
}
