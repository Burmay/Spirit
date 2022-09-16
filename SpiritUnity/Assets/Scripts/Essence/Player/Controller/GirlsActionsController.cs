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

    protected override void HorisontalMove(int dir)
    {
        base.HorisontalMove(dir);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        base.StateMashine();
        //MyDebug();
    }

    public void MyDebug()
    {
        Debug.Log("�� ����� - " + isGrounded + " � ������ - " + isJump + " ������ - " + isFall);
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
