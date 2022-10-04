using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Worms/WeaponData", order = 0)]
public class WeaponData : ScriptableObject
{
    public int damage;
    public int maxAmmo;
    [HideInInspector] public int ammo;
    public int magMaxSize;
    public bool isRocket;
    public float radius;
    public float explosionForce;

    public float speed;
    public float lifeTime;

    public GameObject weapon;
    public GameObject bullet;

    private void OnValidate()
    {
        ammo = maxAmmo;
    }

    public void loadingMag()
    {
        ammo -= magMaxSize;
    }
}
