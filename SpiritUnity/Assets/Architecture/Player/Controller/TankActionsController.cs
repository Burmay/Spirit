using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        unitBehaviourInteractor = Game.GetInteractor<UnitBehaviourInteractor>();
        rigidbody = new Rigidbody2D();
        rigidbody = GetComponent<Rigidbody2D>();

        base.HP = 3;
        this.maxSpeed = 1;
        base.timeAcc = 1f;
        currentSpeed = default;
    }

    protected override void HorisontalMove(int dir)
    {
        base.HorisontalMove(dir);
        rigidbody.position += unitBehaviourInteractor.HorisonMove(currentSpeed, maxSpeed, dir, timeAcc);
    }

    protected override void Fall()
    {
        base.Fall();
        rigidbody.position -= unitBehaviourInteractor.Fall();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void InputProcessing()
    {
        base.InputProcessing();
    }

    protected override void Jump()
    {
        base.Jump();
        rigidbody.position += unitBehaviourInteractor.Jump();
    }
}
