using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : Essence
{
    public bool active;

    //protected UnitBehaviourInteractor unitBehaviourInteractor;

    
    protected void StateMashine()
    {
        if(unitBehaviourInteractor.onCreate == true)
        {
            if (active == true)
            {
                // Начать прыжок или продолжить его
                if (Input.GetKey(KeyCode.W) && isGrounded == true || Input.GetKey(KeyCode.W) && isJump)
                {
                    jumpTime += Time.fixedDeltaTime;
                    isJump = true;
                    Jump();
                }
                else
                {
                    isJump = false;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    HorisontalMove(1);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    HorisontalMove(-1);
                }
            }
            if (isJump == false && isGrounded == false) isFall = true; fallTime += Time.fixedDeltaTime; Fall();
            if (isGrounded == true) isFall = false;
            if (isJump == false) jumpTime = default;
            if (isFall == false) fallTime = default;
        }

    }

    protected virtual void HorisontalMove(int dir)
    {

    }

    protected override void Fall()
    {
        
    }

    protected virtual void Jump()
    {
        jumpValue = unitBehaviourInteractor.Jump(jumpTime, accB);
        if (jumpValue.y < 0)
        {
            isJump = false;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    
}
