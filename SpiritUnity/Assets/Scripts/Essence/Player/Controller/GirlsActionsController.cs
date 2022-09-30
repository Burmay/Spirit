using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlsActionsController : UnitBase
{

    protected override void Start()
    {
        base.Start();
        base.HP = 3;
        base.maxSpeed = 3;
        base.timeAcc = 0.2f;
        abilityTojump = true;
    }

    protected override void HorisontalMove(int dir, bool walk = true)
    {
        base.HorisontalMove(dir, walk);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        base.StateMashine();
        //MyDebug();
    }

    public void MyDebug()
    {
        Debug.Log("На земле - " + isGrounded + " в прыжке - " + isJump + " Падает - " + isFall);
    }

    protected override void Fall()
    {
        base.Fall();
    }

    protected override void Jump()
    {
        base.Jump();
    }
}
