using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private int damage;
    private float speed;
    private float radius;
    private float explosionForce;
    private float lifeTime;
    private Rigidbody rb;
    private ParticleSystem ps;
    [SerializeField] private GameObject explosion;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = -transform.forward * speed * Time.deltaTime;

        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Explode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Explode();
    }

    public void SetData(WeaponData weaponData)
    {
        damage = weaponData.damage;
        speed = weaponData.speed;
        radius = weaponData.radius;
        explosionForce = weaponData.explosionForce;
        lifeTime = weaponData.lifeTime;
    }

    private void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Collider[] playersHit = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider player in playersHit)
        {
            if (player.CompareTag("Player"))
            {
                player.GetComponent<CharacterController>().HealthChange(-damage);

                player.transform.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, radius);
                player.transform.GetComponent<Rigidbody>().AddForce((explosionForce / 100) * Vector3.up, ForceMode.Impulse);

                player.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;

                player.GetComponent<CharacterController>().ResetColor();
            }
        }
        Destroy(this.gameObject);

    }
}
