using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding
{
    private Cost openList, closeList;

}

public struct Cost
{
    public int gCost; // от начала
    public int hCost; // от конца
    public int fCost; // сумма
}
