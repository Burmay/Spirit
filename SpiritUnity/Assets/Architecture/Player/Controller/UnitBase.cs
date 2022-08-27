using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public int HP;
    public bool acteve, isGrounded, isJump;
    public float maxSpeed, currentSpeed, timeAcc, checkGoundRadius;
    public Transform groudCheck;
    public LayerMask whatIsGround;

    protected UnitBehaviourInteractor unitBehaviourInteractor;

    
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
        if(acteve == true)
        {
            InputProcessing();
        }
        if(Physics2D.OverlapCircle(groudCheck.position, checkGoundRadius, whatIsGround) == false && isJump == false)
        {
            Fall();
        }
    }
    

    protected virtual void InputProcessing()
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
