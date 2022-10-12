using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteAmmo : MonoBehaviour
{
    [SerializeField] private CheatCode cheatCode;

    private void OnEnable()
    {
        CheatCode.OnCheatCodeEntered += ActivateInfiniteAmmo;
    }

    private void ActivateInfiniteAmmo()
    {
        Debug.Log("Infinite Ammo Activated");
    }
}
