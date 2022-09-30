using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("References")]
    [Space(10)]
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private WeaponData[] weapons;

    [Space(20)]
    [Header("Configurations")]
    [Space(10)]
    [SerializeField] private int shotsLeft = 2;
    private int activeWeapon = 0;
    private GameObject[] instantiatedWeapons;
    private Transform cameraTransform;
    public bool isActive = true;

    delegate void UpdateShotsLeft(int shotsLeft);

    private InGameUI gameUI;

    private void Awake()
    {
        instantiatedWeapons = new GameObject[weapons.Length];
        cameraTransform = Camera.main.transform;
        gameUI = InGameUI.instance;

        UpdateShotsLeft updateShotsLeft = gameUI.UpdateShotsLeft;
    }

    private void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            GameObject instWeapon = Instantiate(weapons[i].weapon, weaponHolder);

            instWeapon.SetActive(i == activeWeapon);

            instantiatedWeapons[i] = instWeapon;
        }
    }

    private void Update()
    {
        if (shotsLeft > 0)
        {
            if (Input.GetMouseButtonDown(0)) Fire();
        }
        else if (isActive)
        {
            isActive = false;
            StartCoroutine("NextPlayer");
        }


        if (Input.GetKeyDown(playerControls.swapWeapon))
            ChangeActiveWeapon();

        if (Input.GetMouseButton(1))
        {
            Vector3 weaponAngle = new Vector3(-cameraTransform.rotation.eulerAngles.x, cameraTransform.rotation.eulerAngles.y + 180, cameraTransform.rotation.eulerAngles.z);
            AngleWeapon(Quaternion.Euler(weaponAngle), false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            AngleWeapon(Quaternion.Euler(0, 0, 0), true);
        }
    }

    private void ChangeActiveWeapon()
    {
        activeWeapon = activeWeapon + 1 >= weapons.Length ? 0 : activeWeapon += 1;

        for (int i = 0; i < instantiatedWeapons.Length; i++)
        {
            instantiatedWeapons[i].SetActive(i == activeWeapon);
        }
    }

    private void Fire()
    {
        shotsLeft--;
        gameUI.UpdateShotsLeft(shotsLeft);

        weapons[activeWeapon].ammo--;

        int childCount = instantiatedWeapons[activeWeapon].transform.childCount;
        Transform bulletSpawn = instantiatedWeapons[activeWeapon].transform.GetChild(childCount - 1);

        GameObject bullet = Instantiate(weapons[activeWeapon].bullet, bulletSpawn.position, bulletSpawn.rotation);
        if (weapons[activeWeapon].isRocket)
        {
            bullet.GetComponent<Rocket>().SetData(weapons[activeWeapon]);
        }
        else
        {
            bullet.GetComponent<Bullet>().SetData(weapons[activeWeapon]);
        }
    }

    private void AngleWeapon(Quaternion rotation, bool isLocal)
    {
        if (isLocal)
        {
            instantiatedWeapons[activeWeapon].transform.localRotation = rotation;
        }
        else
        {
            instantiatedWeapons[activeWeapon].transform.rotation = rotation;
        }
    }

    public void Reset()
    {
        shotsLeft = 2;
        gameUI.UpdateShotsLeft(shotsLeft);
    }

    private IEnumerator NextPlayer()
    {
        yield return new WaitForSeconds(1);

        GameManager.instance.NextPlayer();
    }
}
