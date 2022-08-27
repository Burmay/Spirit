using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        unitBehaviourInteractor = Game.GetInteractor<UnitBehaviourInteractor>();
        rigidbody = new Rigidbody2D();
        rigidbody = GetComponent<Rigidbody2D>();

        base.HP = 1;
        base.maxSpeed = 1.5f;
        base.timeAcc = 0.7f;
        currentSpeed = default;
    }

    protected override void HorisontalMove(int dir)
    {
        rigidbody.position += unitBehaviourInteractor.HorisonMove(currentSpeed, maxSpeed, dir, timeAcc);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void InputProcessing()
    {
        base.InputProcessing();
    }

    protected override void Fall()
    {
        base.Fall();
        rigidbody.position -= unitBehaviourInteractor.Fall();
    }

    protected override void Jump()
    {
        base.Jump();
        rigidbody.position += unitBehaviourInteractor.Jump();
    }
}
