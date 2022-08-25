using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.GetComponent<Rigidbody2D>();
        base.HP = 2;
        base.maxSpeed = 2;
        base.timeAcc = 0.5f;
        currentSpeed = default;
    }

    public override void SetLink(UnitBehaviourInteractor unitBehaviourInteractor)
    {
        base.SetLink(unitBehaviourInteractor);
    }

    protected override void HorisontalMove(int dir)
    {
        rigidbody.position += new Vector2(0, unitBehaviourInteractor.HorisonMove(currentSpeed, maxSpeed, dir, timeAcc));
    }

    void Update()
    {
        InputProcessing();
    }

    protected override void InputProcessing()
    {
        base.InputProcessing();
    }
}
