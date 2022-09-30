using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorActionsController : UnitBase
{

    protected override void Start()
    {
        base.Start();
        base.HP = 2;
        base.maxSpeed = 2;
        base.timeAcc = 0.5f;
        abilityTojump = false;
    }

    protected override void HorisontalMove(int dir, bool walk = true)
    {
        base.HorisontalMove(dir, walk);
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
}
