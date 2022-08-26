using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public int HP;
    public float maxSpeed, currentSpeed, timeAcc;

    protected UnitBehaviourInteractor unitBehaviourInteractor;

    
    protected virtual void HorisontalMove(int dir)
    {

    }

    protected virtual void Update()
    {
        InputProcessing();
    } 

    protected virtual void InputProcessing()
    {
        if (Input.GetKey(KeyCode.D))
        {
            HorisontalMove(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            HorisontalMove(-1);
        }
    }
}
