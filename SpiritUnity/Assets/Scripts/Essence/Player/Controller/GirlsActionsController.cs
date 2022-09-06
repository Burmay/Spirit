using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlsActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        //unitBehaviourInteractor = Game.GetInteractor<UnitBehaviourInteractor>();
        rigidbody = new Rigidbody2D();
        rigidbody = GetComponent<Rigidbody2D>();

        base.HP = 3;
        base.maxSpeed = 3;
        base.timeAcc = 0.2f;
        currentSpeed = default;

        GetLink();
    }

    protected override void HorisontalMove(int dir)
    {
        rigidbody.position += (unitBehaviourInteractor.HorisonMove(currentSpeed, maxSpeed, dir, timeAcc));
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        base.StateMashine();
    }

    public void MyDebug()
    {
        Debug.Log("На земле - " + isGrounded + " в прыжке - " + isJump + " Падает - " + isFall);
    }

    protected override void Fall()
    {
        base.Fall();
        //Debug.Log("Fall - " + unitBehaviourInteractor.Fall(fallTime, fallB) + " Jump - " + unitBehaviourInteractor.Jump(jumpTime, accB));
        rigidbody.position += unitBehaviourInteractor.Fall(fallTime, fallB);
    }

    protected override void Jump()
    {
        base.Jump();
        if(isJump == true)
        {
            rigidbody.position += unitBehaviourInteractor.Jump(jumpTime, accB);
        }
    }
}
