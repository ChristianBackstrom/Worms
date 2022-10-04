using UnityEngine;

[CreateAssetMenu(fileName = "CheatCode", menuName = "Worms/CheatCode", order = 0)]
public class CheatCode : ScriptableObject
{
    [SerializeField] private KeyCode[] keys;
    [SerializeField] private float timeToType;
    public static event System.Action OnCheatCodeEntered;


    public void CheckForCheatCode()
    {
        float timer = 0;

        int correctKeyPresses = 0;

        if (Input.GetKeyDown(keys[0]))
        {
            Debug.Log("First Key Pressed");
            for (int i = 1; i < keys.Length; i++)
            {
                while (timer < timeToType)
                {
                    timer += Time.deltaTime;
                    Debug.Log("Timer: " + timer);
                    if (Input.GetKeyDown(keys[i]))
                    {
                        timer = 0;
                        correctKeyPresses++;
                        Debug.Log("Correct Key Pressed");
                        if (correctKeyPresses >= keys.Length - 1)
                        {
                            OnCheatCodeEntered?.Invoke();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}