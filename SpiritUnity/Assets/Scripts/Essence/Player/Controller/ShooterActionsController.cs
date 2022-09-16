using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterActionsController : UnitBase
{

    protected override void Start()
    {
        base.Start();
        base.HP = 1;
        base.maxSpeed = 1.5f;
        base.timeAcc = 0.7f;
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
