using System.Collections;
using UnityEngine;
using TMPro;

public class WinScene : MonoBehaviour
{
    public static WinScene instance;

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
    }

    [Header("References")]
    [SerializeField] private TextMeshProUGUI winText;

    private void Start()
    {
        StartCoroutine("LoadMainMenu");
    }

    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManagement.instance.LoadMenuScene();
    }

    public void SetWinText(int winningTeam, Color winningColor)
    {
        winText.text = string.Format("Team <color={0}>{1}</color> Wins!", convertRGBTOHex(winningColor), winningTeam + 1);
    }

    string convertRGBTOHex(Color color)
    {
        return "#" + ColorUtility.ToHtmlStringRGB(color);
    }
}
