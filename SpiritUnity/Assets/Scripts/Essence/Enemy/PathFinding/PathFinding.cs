using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding
{
    // ѕолучаем начальные координаты, конечные координаты, размер сетки

    int startPosX, startPosY, endPosX, endPosY, gridSizeX, gridSizeY, minCellX, minCellY;

    Cost[,] openList;
    bool[,] closeList;
    bool[,] routerCloseList;
    int[,] route = new int[50, 1];
    bool stopFlag = false;

    public PathFinding()
    {

    }

    public void StartFinding(Vector2 gridCq, Vector2 startPos, Vector2 endPos)
    {
        startPosX = (int)startPos.x;
        startPosY = (int)startPos.y;
        endPosX = (int)endPos.x;
        endPosY = (int)endPos.y;
        gridSizeX = (int)gridCq.x;
        gridSizeY = (int)gridCq.y;
        openList = new Cost[gridSizeX, gridSizeY];
        openList[startPosX, startPosY].gCost = 0;
        GetHCost(startPosX, startPosY);
        GetFCost(startPosX, startPosY);
        minCellX = gridSizeX * 15; minCellY = gridSizeY * 15;

        Test();

    }

    private void Test()
    {
        for (int i = 0; i < 20; i++)
        {
            Debug.Log(route[i, 0]);
            Debug.Log(route[i, 1]);
        }
    }


    private void GetGCost(int x, int y)
    {
        int diagonal, line;

        if (startPosX - x > 0)
        {
            line = startPosX - x;
        }
        else
        {
            line = x - startPosX;
        }

        if (startPosY - y > 0)
        {
            line += startPosY - y;
        }
        else
        {
            line += y - startPosY;
        }

        if (x > y)
        {
            if (startPosY - y > 0)
            {
                diagonal = startPosY - y;
            }
            else
            {
                diagonal = y - startPosY;
            }
        }
        else
        {
            if (startPosX - x > 0)
            {
                diagonal = startPosX - x;
            }
            else
            {
                diagonal = x - startPosX;
            }
        }
        line -= diagonal * 2;
        openList[x, y].gCost = line * 10 + diagonal * 14;
    }


    private void GetHCost(int x, int y)
    {
        int diagonal, line;

        if (endPosX - x > 0)
        {
            line = endPosX - x;
        }
        else
        {
            line = x - endPosX;
        }

        if (endPosY - y > 0)
        {
            line += endPosY - y;
        }
        else
        {
            line += y - endPosY;
        }

        if (x > y)
        {
            if (endPosY - y > 0)
            {
                diagonal = endPosY - y;
            }
            else
            {
                diagonal = y - endPosY;
            }
        }
        else
        {
            if (endPosX - x > 0)
            {
                diagonal = endPosX - x;
            }
            else
            {
                diagonal = x - endPosX;
            }
        }
        line -= diagonal * 2;
        openList[x, y].gCost = line * 10 + diagonal * 14;
    }


    private void GetFCost(int x, int y)
    {
        openList[x, y].fCost = openList[x, y].gCost + openList[x, y].hCost;
    }
}

public struct Cost
{
    public int gCost; // от начала
    public int hCost; // от конца
    public int fCost; // сумма
}
