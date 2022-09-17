using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitBase : Essence
{
    [SerializeField] protected SpriteRenderer renderer;

    public bool active, abilityTojump, isTurn, prevDir, newDir;
    protected Animator animator;
    protected float speed, maxTurnTime, currentTurnTime;
    protected Rigidbody2D rigidbody;

    //protected UnitBehaviourInteractor unitBehaviourInteractor;

    protected virtual void Start()
    {
        rigidbody = new Rigidbody2D();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = new Animator();
        animator = GetComponent<Animator>();
        renderer = new SpriteRenderer();
        renderer = GetComponent<SpriteRenderer>();
        GetLink();
        currentSpeed = default;
        prevDir = true;
        newDir = true;
        maxTurnTime = 0.5f;
    }

    protected void StateMashine()
    {
        if(unitBehaviourInteractor.onCreate == true)
        {
        
            if (active == true)
            {

                if (prevDir != newDir || isTurn == true) { Turn(); }

                // Начать прыжок или продолжить его
                if ((Input.GetKey(KeyCode.W) && isGrounded == true) || (Input.GetKey(KeyCode.W) && isJump) && abilityTojump == true)
                {
                    Jump();
                }
                else
                {
                    isJump = false;
                }
                prevDir = newDir;
                if(speed > 0)
                {
                    newDir = true;
                }
                else
                {
                    prevDir = false;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                {

                    if (Input.GetKey(KeyCode.D) && isTurn == false)
                    {
                        HorisontalMove(1);
                    }
                    if (Input.GetKey(KeyCode.A) && isTurn == false)
                    {
                        HorisontalMove(-1);
                    }
                    animator.SetFloat("Speed", Math.Abs(speed/ Time.fixedDeltaTime));
                    animator.SetBool("Stop", false);
                }
                else
                {
                    animator.SetBool("Stop", true);
                }
            }
            if (isJump == false && isGrounded == false) { isFall = true; fallTime += Time.fixedDeltaTime; Fall(); }
            if (isGrounded == true) { isFall = false; }
            if (isJump == false) { jumpTime = default; }
            if (isFall == false) { fallTime = default; }
        }

    }

    protected virtual void HorisontalMove(int dir)
    {
        speed = unitBehaviourInteractor.HorisonMove(currentSpeed, maxSpeed, dir, timeAcc);
        rigidbody.position += new Vector2(speed, 0);
    }

    protected override void Fall()
    {
        rigidbody.position += unitBehaviourInteractor.Fall(fallTime, fallB);
    }

    protected virtual void Jump()
    {
        jumpTime += Time.fixedDeltaTime;
        isJump = true;
        jumpValue = unitBehaviourInteractor.Jump(jumpTime, accB);
        if (jumpValue.y < 0)
        {
            isJump = false;
        }
        else
        {
            rigidbody.position += unitBehaviourInteractor.Jump(jumpTime, accB);
        }
    }

    protected virtual void Turn()
    {
        currentTurnTime += Time.fixedDeltaTime;
        Debug.Log(currentTurnTime);
        if(currentTurnTime < maxTurnTime)
        {
            isTurn = true;
            animator.SetBool("IsTurn", true);
        }
        else
        {
            isTurn = false;
            animator.SetBool("IsTurn", false);
             currentTurnTime = default;
            renderer.flipX = newDir;
        }

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    
}
