using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform combatLookAt;
    [SerializeField] private Transform playerObj;
    [Space(10)]
    [SerializeField] private float rotationSpeed;
    [Space(10)]
    [SerializeField] private CameraStyle currentStyle;
    [Space(20)]
    [SerializeField] public GameObject basicCam, combatCam;
    private Camera mainCam;

    public enum CameraStyle
    {
        basic,
        combat
    }

    private void Start()
    {
        mainCam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(mainCam.transform.position.x, player.position.y, mainCam.transform.position.z);
        orientation.forward = viewDir.normalized;

        if (currentStyle == CameraStyle.basic)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
        else if (currentStyle == CameraStyle.combat)
        {
            Vector3 dirToCombatLook = combatLookAt.position - new Vector3(mainCam.transform.position.x, combatLookAt.position.y, mainCam.transform.position.z);
            orientation.forward = dirToCombatLook.normalized;

            playerObj.forward = dirToCombatLook.normalized;
        }

        Aim();

    }

    public void SwitchCameraStyle(CameraStyle newStyle)
    {
        combatCam.SetActive(false);
        basicCam.SetActive(false);

        if (newStyle == CameraStyle.basic) basicCam.SetActive(true);
        if (newStyle == CameraStyle.combat) combatCam.SetActive(true);

        currentStyle = newStyle;
    }

    public void Deactivate()
    {
        basicCam.SetActive(false);
        combatCam.SetActive(false);
    }

    private void Aim()
    {
        if (Input.GetMouseButtonDown(1)) SwitchCameraStyle(ThirdPersonCamera.CameraStyle.combat);
        if (Input.GetMouseButtonUp(1)) SwitchCameraStyle(ThirdPersonCamera.CameraStyle.basic);
    }
}
