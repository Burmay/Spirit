using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = new Rigidbody2D();
        rigidbody = GetComponent<Rigidbody2D>();

        base.HP = 3;
        this.maxSpeed = 1;
        base.timeAcc = 1f;
        currentSpeed = default;

        GetLink();
    }

    protected override void HorisontalMove(int dir)
    {
        base.HorisontalMove(dir);
        rigidbody.position += unitBehaviourInteractor.HorisonMove(currentSpeed, maxSpeed, dir, timeAcc);
    }

    protected override void Fall()
    {
        base.Fall();
        rigidbody.position += unitBehaviourInteractor.Fall(fallTime, fallB);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        base.StateMashine();
    }

}
