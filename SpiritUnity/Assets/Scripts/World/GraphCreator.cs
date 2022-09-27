using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GraphCreator : MonoBehaviour
{
    public GameObject[] allGround;
    public GameObject graphObj;
    bool[,] graphs;
    private float heightUp, width, height, rightX, leftX;

    public void Start()
    {
        int j = 0;
        int k = 0;
        allGround = GameObject.FindGameObjectsWithTag("Ground");

        foreach(GameObject ground in allGround)
        {
            GetSize();
            for (int i = 0; i < Math.Abs(leftX - rightX); i++)
            {
                Instantiate(graphObj, new Vector3(leftX + i + 0.5f, transform.position.y + height / 2 + heightUp, transform.position.z), Quaternion.identity);
                
            }
            j++;
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
        //leftY = transform.position.y - width / 2;
        //rightY = transform.position.y + width / 2;
    }
}
