using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private void Start()
    {
        GameManager.instance.players[0].Deactivate();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameManager.instance.players[0].Activate();
            Destroy(gameObject);
        }
    }
}
