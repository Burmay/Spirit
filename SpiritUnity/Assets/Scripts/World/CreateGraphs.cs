using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGraphs : MonoBehaviour
{
    public GameObject graph;
    public float height;

    void Start()
    {
        height = 1f;
        for (var i = 0; i < 30; i++)
        {
            Instantiate(graph, new Vector3(transform.position.x + i, transform.position.y + height, transform.position.z), Quaternion.identity);
        }
    }

}
