using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private float lifeTime;
    private float speed;
    private Rigidbody rb;

    private void Awake()
    {
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().HealthChange(-damage);
            other.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;

            other.GetComponent<CharacterController>().ResetColor();
        }

        Destroy(this.gameObject);
    }

    public void SetData(WeaponData weaponData)
    {
        damage = weaponData.damage;
        lifeTime = weaponData.lifeTime;
        speed = weaponData.speed;
    }
}
