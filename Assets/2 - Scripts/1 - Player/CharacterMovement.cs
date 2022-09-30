using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private PlayerMovementValues playerMovementValues;
    [SerializeField] private PlayerControls playerControls;
    [Space(10)]

    [Header("Ground checks")]
    [SerializeField] private LayerMask groundLayer;

    private float horizontalInput, verticalInput;
    private bool isGrounded;
    private bool isJumping;


    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        GroundedCheck();
    }

    private void FixedUpdate()
    {
        if (isGrounded)
            rb.velocity = orientation.right * horizontalInput * playerMovementValues.maxSpeed * Time.fixedDeltaTime + orientation.forward * verticalInput * playerMovementValues.maxSpeed * Time.fixedDeltaTime + Vector3.up * rb.velocity.y;

        if (Input.GetKey(playerControls.jump) && isGrounded)
            Jump();
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * playerMovementValues.jumpForce, ForceMode.Impulse);
    }

    private void GroundedCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerMovementValues.RayCastLength, groundLayer);
    }
}
