using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankActionsController : UnitBase
{

    protected override void Start()
    {
        base.Start();
        base.HP = 3;
        base.maxSpeed = 1;
        base.timeAcc = 1f;
        abilityTojump = false;
    }

    protected override void HorisontalMove(int dir)
    {
        base.HorisontalMove(dir);
    }

    protected override void Fall()
    {
        base.Fall();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        base.StateMashine();
    }

}
