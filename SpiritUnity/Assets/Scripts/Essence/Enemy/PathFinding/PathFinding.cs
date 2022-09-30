using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : Interactor
{
    GameObject[] graphsTag;
    GameObject[,] graphs;

    //public override void OnStart()
    //{
    //    base.OnStart();
    //
    //    graphsTag = GameObject.FindGameObjectsWithTag("Graph");
    //    int platform = 0;
    //    int arrayN = 0;
    //    for (int i = 0; i < graphsTag.Length; i++)
    //    {
    //        if(graphsTag[i+1].transform.position.x < graphsTag[i].transform.position.x)
    //        {
    //            platform++;
    //            arrayN = default;
    //            graphs[arrayN, platform] = graphsTag[i];
    //        }
    //        else
    //        {
    //            graphs[arrayN, platform] = graphsTag[i];
    //            arrayN++;
    //        }
    //        Debug.Log(i);
    //    }
    //
    //}

}
