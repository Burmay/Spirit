using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    public int HP;
    protected bool isGrounded, isJump, isFall, isChangeDir;
    [SerializeField] protected float maxSpeed, checkGoundRadius, accB, fallB, Direction;
    [SerializeField] protected float fallTime, jumpTime, timeAcc;
    protected float currentSpeed;
    [SerializeField] protected Transform groudCheck;
    public LayerMask whatIsGround;
    [SerializeField] protected Vector2 jumpValue;

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
