using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{

    public static InGameUI instance;

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
    [SerializeField] private TextMeshProUGUI shotsLeft;

    public void UpdateShotsLeft(int shotsLeft)
    {
        this.shotsLeft.text = shotsLeft.ToString();
    }
}
