using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovement", menuName = "Player/Movement", order = 0)]
public class PlayerMovementValues : ScriptableObject
{
    [Header("Movement")]
    [Space(30)]

    [Header("Run")]
    [Space(10)]
    public float maxSpeed;

    [Space(20)]

    [Header("Jump")]
    [Space(10)]
    public float jumpForce;

    [Space(20)]

    [Header("GroundCollision")]
    [Space(10)]

    public float RayCastLength, coyoteTime, gravityScale;
}
