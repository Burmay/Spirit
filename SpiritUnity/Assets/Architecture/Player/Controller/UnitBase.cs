using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public int HP;
    public bool active, isGrounded, isJump;
    public float maxSpeed, currentSpeed, timeAcc, checkGoundRadius;
    public Transform groudCheck;
    public LayerMask whatIsGround;

    protected UnitBehaviourInteractor unitBehaviourInteractor;

    
    protected void StateMashine()
    {
        if(active == true)
        {
            if (isGrounded == true)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    HorisontalMove(1);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    HorisontalMove(-1);
                }
            }
        }
        if(isGrounded == true && isJump == true)
        {
            isJump = false;
            unitBehaviourInteractor.jumpTime = 0;
        }
        if (isJump == false && isGrounded == false)
        {
            Fall();
        }
        if (Input.GetKey(KeyCode.W) || isJump == true)
        {
            Jump();
            isJump = true;
            isGrounded = false;
        }

    }

    protected virtual void HorisontalMove(int dir)
    {

    }

    protected virtual void Fall()
    {

    }

    protected virtual void Jump()
    {

    }

    protected virtual void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groudCheck.position, checkGoundRadius, whatIsGround);
    }
    
}
