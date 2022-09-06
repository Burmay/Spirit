using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    public int HP;
    public bool isGrounded, isJump, isFall;
    public float maxSpeed, checkGoundRadius, accB, fallB;
    protected float currentSpeed, fallTime, jumpTime, timeAcc;
    public Transform groudCheck;
    public LayerMask whatIsGround;
    public Vector2 jumpValue;

    protected UnitBehaviourInteractor unitBehaviourInteractor;

    protected void GetLink()
    {
        unitBehaviourInteractor = Game.GetInteractor<UnitBehaviourInteractor>();
    }

    protected virtual void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groudCheck.position, checkGoundRadius, whatIsGround);
    }

    protected virtual void Fall()
    {

    }
}
