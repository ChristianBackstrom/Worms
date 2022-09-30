using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{
    private GameObject[] trees;
    [SerializeField] private float maxScale = 1.5f;

    private void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Trees");
        foreach (GameObject tree in trees)
        {
            float size = Random.Range(0, maxScale);
            tree.transform.localScale += new Vector3(size, size, size);
        }
    }

}
