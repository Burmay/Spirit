using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitBase : Essence
{
    [SerializeField] protected SpriteRenderer renderer;

    protected bool  abilityTojump, isTurn, slowingDown, walk;
    public bool active;
    protected Animator animator;
    [SerializeField] protected float speed, turnDelay;
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

        animator.SetBool("Stop", true);
    }

    protected void StateMashine()
    {
        if(unitBehaviourInteractor.onCreate == true)
        {
            // Если выбран он
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

                // Двигаться на крейсерской или начать поворот
                if ((Input.GetKey(KeyCode.D) && slowingDown == false) || (Input.GetKey(KeyCode.A) && slowingDown == false))
                {


                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                    {

                        if (Input.GetKey(KeyCode.D) && isTurn == false && slowingDown == false)
                        {
                            if (renderer.flipX == true)
                            {
                                if (isTurn == false)
                                {
                                    StartTurn();
                                }
                                isTurn = true;
                            }
                            else
                            {
                                HorisontalMove(1);
                                animator.SetBool("Stop", false);
                            }
                        }
                        if ((Input.GetKey(KeyCode.A) && isTurn == false) && slowingDown == false)
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
                                animator.SetBool("Stop", false);
                            }
                        }
                    }
                }
                // разгоняться или тормозить
                else if (slowingDown == true)
                {
                    if (renderer.flipX == false)
                    {
                        HorisontalMove(1, false);
                    }
                    else
                    {
                        HorisontalMove(-1, false);
                    }
                }

                // продолжать двигаться до конца анимации
                else if(walk == true)
                {
                    if (renderer.flipX == false)
                    {
                        HorisontalMove(1);
                    }
                    else
                    {
                        HorisontalMove(-1);
                    }
                }
                else
                {
                    animator.SetBool("Stop", true);
                }
            }
            // счёт времени прыжка и падения для разгона
            if (isJump == false && isGrounded == false) { isFall = true; fallTime += Time.fixedDeltaTime; Fall(); }
            if (isGrounded == true) { isFall = false; }
            if (isJump == false) { jumpTime = default; }
            if (isFall == false) { fallTime = default; }
        }

    }

    private void StartTurn()
    {
        //Invoke("Turn", turnDelay);
        animator.SetBool("DirChange", true);
        animator.SetBool("Stop", true);
    }

    protected virtual void HorisontalMove(int dir, bool walk = true)
    {
        speed = unitBehaviourInteractor.HorisonMove(currentSpeed, maxSpeed, dir, timeAcc);
        if(walk == true)
        {
            rigidbody.position += new Vector2(speed, 0);
        }
        else
        {
            rigidbody.position += new Vector2(speed/1.5f, 0);
        }
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

    protected virtual void TurnOff()
    {
        Debug.Log("EventTurn");
        if(renderer.flipX == false) { renderer.flipX = true; }
        else if(renderer.flipX == true) { renderer.flipX = false; }
        //renderer.flipX = renderer.flipX = true ? true : false;
        isTurn = false;
        animator.SetBool("DirChange", false);
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


    public void SlowingDownOn()
    {
        slowingDown = true;
    }
    public void SlowingDownOff()
    {
        slowingDown = false;
    }
    public void WalkOn()
    {
        walk = true;
    }
    public void WalkOff()
    {
        walk = false;
    }

    public void TurnOn()
    {
        isTurn = true;
    }
    public void StopAfterWalk()
    {
        if((renderer.flipX == true && Input.GetKey(KeyCode.A) == false) || (renderer.flipX == false && Input.GetKey(KeyCode.D) == false))
        {
            animator.SetBool("StopAfterWalk", true);
        }
    }
    public void StopAfterWalkReset()
    {
        animator.SetBool("StopAfterWalk", false);
    }



}
