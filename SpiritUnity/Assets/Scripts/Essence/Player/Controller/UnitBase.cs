using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitBase : Essence
{
    public bool active, abilityTojump;
    protected Animator animator;
    protected float speed;
    protected Rigidbody2D rigidbody;

    //protected UnitBehaviourInteractor unitBehaviourInteractor;

    protected virtual void Start()
    {
        rigidbody = new Rigidbody2D();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = new Animator();
        animator = GetComponent<Animator>();
        GetLink();
        currentSpeed = default;
    }

    protected void StateMashine()
    {
        if(unitBehaviourInteractor.onCreate == true)
        {
            if (active == true)
            {
                // Начать прыжок или продолжить его
                if (Input.GetKey(KeyCode.W) && isGrounded == true || Input.GetKey(KeyCode.W) && isJump && abilityTojump == true)
                {
                    Jump();
                }
                else
                {
                    isJump = false;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        animator.SetBool("Dir", true);
                        HorisontalMove(1);
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        HorisontalMove(-1);
                        animator.SetBool("Dir", false);
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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    
}
