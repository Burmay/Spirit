using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GraphsInteractor : Interactor
{
    GameObject[] allGround, allGraphs;
    [SerializeField] GameObject graphObj;
    Graph[,] graphs;
    float heightUp, width, height, rightX, leftX;

    public override void OnStart()
    {
        graphs = new Graph[50, 1000];
        allGround = GameObject.FindGameObjectsWithTag("Ground");

        for(int i = 0; i < allGround.Length; i++)
        {
            GetSize(i);
            for (int j = 0; j < Math.Abs(leftX - rightX); j++)
            {
                //Instantiate(graphObj, new Vector3(leftX + i + 0.5f, ground.transform.position.y + height / 2 + heightUp, ground.transform.position.z), Quaternion.identity);
                graphs[i, j].Pos = new Vector2(leftX + j + 0.5f, allGround[i].transform.position.y + height / 2 + heightUp);
                Debug.Log(graphs[i, j].Pos.x + " Ðÿä " + i);
            }
        }

        

    }


    private void GetSize(int i)
    {
        width = allGround[i].transform.localScale.x;
        height = allGround[i].transform.localScale.y;

        leftX = allGround[i].transform.position.x - width / 2;
        rightX = allGround[i].transform.position.x + width / 2;
    }
}

