using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlsActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        unitBehaviourInteractor = Game.GetInteractor<UnitBehaviourInteractor>();
        rigidbody = new Rigidbody2D();
        rigidbody = GetComponent<Rigidbody2D>();

        base.HP = 3;
        base.maxSpeed = 3;
        base.timeAcc = 0.2f;
        currentSpeed = default;
    }

    protected override void HorisontalMove(int dir)
    {
        rigidbody.position += new Vector2(unitBehaviourInteractor.HorisonMove(currentSpeed, maxSpeed, dir, timeAcc), 0);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void InputProcessing()
    {
        base.InputProcessing();
    }
}
