using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateGraphs : MonoBehaviour
{
    public GameObject graph;
    private float heightUp, width, height, rightX, leftX, rightY, leftY;

    void Start()
    {
        heightUp = 0.5f;
        GetSize();
        for (int i = 0; i < Math.Abs(leftX - rightX); i++)
        {
            Instantiate(graph, new Vector3(leftX + i + 0.5f, transform.position.y + height/2 + heightUp, transform.position.z), Quaternion.identity);
        }

    }

    private void GetSize()
    {
        width = transform.localScale.x;
        height = transform.localScale.y;

        //x
        leftX = transform.position.x - width / 2;
        rightX = transform.position.x + width / 2;
        //y
        leftY = transform.position.y - width / 2;
        rightY = transform.position.y + width / 2;
    }

}
