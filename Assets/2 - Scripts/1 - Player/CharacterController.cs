using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : Health
{
    [Header("References")]
    [SerializeField] private ThirdPersonCamera thirdPersonCamera;
    [HideInInspector] public int playerId;
    [HideInInspector] public int teamId;
    [SerializeField] private Image healthBar;
    private Color color;


    private void Start()
    {
        color = GetComponentInChildren<MeshRenderer>().material.color;
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }

        healthBar.fillAmount = (float)health / maxHealth;
    }

    public void Death()
    {
        GameManager.instance.PlayerDeath(teamId, playerId);
    }

    public void ResetColor()
    {
        StartCoroutine("ResetColorAfterTime");

    }

    private IEnumerator ResetColorAfterTime()
    {
        yield return new WaitForSeconds(0.3f);
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = color;
    }
}
