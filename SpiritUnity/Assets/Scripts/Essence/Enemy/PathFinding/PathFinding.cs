using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding
{
    private Cost openList, closeList;

}

public struct Cost
{
    public int gCost; // �� ������
    public int hCost; // �� �����
    public int fCost; // �����
}
