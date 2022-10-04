using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControls", menuName = "Player/Controls", order = 0)]
public class PlayerControls : ScriptableObject
{
    [Header("Controls")]
    [Space(30)]

    [Header("Movement")]
    [Space(10)]
    public KeyCode jump;

    [Space(20)]
    [Header("Weapon")]
    [Space(10)]

    public KeyCode swapWeapon;
}
