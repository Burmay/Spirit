using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitBase : Essence
{
    [SerializeField] protected SpriteRenderer renderer;

    public bool active, abilityTojump, isTurn;
    protected Animator animator;
    public float speed, turnDelay;
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
        turnDelay = 1f;
    }

    protected void StateMashine()
    {
        if(unitBehaviourInteractor.onCreate == true)
        {
        
            if (active == true)
            {
                // Начать прыжок или продолжить его
                if (((Input.GetKey(KeyCode.W) && isGrounded == true) || (Input.GetKey(KeyCode.W) && isJump)) && abilityTojump == true)
                {
                    Jump();
                }
                else
                {
                    isJump = false;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                {

                    if (Input.GetKey(KeyCode.D) && isTurn == false)
                    {
                        if(renderer.flipX == true)
                        {
                            if(isTurn == false)
                            {
                                StartTurn();
                            }
                            isTurn = true;
                        }
                        else
                        {
                            HorisontalMove(1);
                        }
                    }
                    if (Input.GetKey(KeyCode.A) && isTurn == false)
                    {
                        if (renderer.flipX == false)
                        {
                            if (isTurn == false)
                            {
                                StartTurn();
                            }
                            isTurn = true;
                        }
                        else
                        {
                            HorisontalMove(-1);
                        }
                    }
                    animator.SetFloat("Speed", Math.Abs(speed/ Time.fixedDeltaTime));
                    if(animator.GetBool("IsTurn") == false)
                    {
                        animator.SetBool("Stop", false);
                    }
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

    private void StartTurn()
    {
        //Invoke("Turn", turnDelay);
        animator.SetBool("IsTurn", true);
        animator.SetBool("Stop", true);
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

    protected virtual void TurnRender()
    {
        Debug.Log("EventTurn");
        if(renderer.flipX == false) { renderer.flipX = true; }
        else if(renderer.flipX == true) { renderer.flipX = false; }
        //renderer.flipX = renderer.flipX = true ? true : false;
        isTurn = false;
        animator.SetBool("IsTurn", false);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        currentSpeed = rigidbody.velocity.magnitude;
    }

    public void Swich()
    {
        active = false;
        isJump = false;
        animator.SetBool("Stop", true);
    }
    
}
