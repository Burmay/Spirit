using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitBehaviourInteractor : Interactor
{
    GameObject girlTag, tankTag, warriorTag, shooterTag;
    GirlsActionsController girl;
    TankActionsController tank;
    ShooterActionsController shooter;
    WarriorActionsController warrior;
    public bool onCreate;

    Accelerator accelerator;

    public override void OnCreate()
    {
        base.OnCreate();
        girlTag = GameObject.FindGameObjectWithTag("Girl");
        tankTag = GameObject.FindGameObjectWithTag("Tank");
        warriorTag = GameObject.FindGameObjectWithTag("Warrior");
        shooterTag = GameObject.FindGameObjectWithTag("Shooter");

        girl = girlTag.GetComponent<GirlsActionsController>();
        tank = tankTag.GetComponent<TankActionsController>();
        warrior = warriorTag.GetComponent<WarriorActionsController>();
        shooter = shooterTag.GetComponent<ShooterActionsController>();


        accelerator = new Accelerator();
        onCreate = true;
    }   

    public float HorisonMove(float currentSpeed, float maxSpeed, int dir, float timeAcc)
    {
        if(Math.Abs(currentSpeed) >= maxSpeed)
        {
            return 0;
        }
        else
        {
            return accelerator.Acceleration(timeAcc, maxSpeed, currentSpeed, dir);
        }
    }

    public Vector2 Fall(float fallTime, float fallB)
    {
        fallTime += Time.fixedDeltaTime;
        return new Vector2(0, accelerator.FallAccelerator(100, fallTime));
    }

    public Vector2 Jump(float jumpTime, float accB)
    {
        jumpTime += Time.fixedDeltaTime;
        return new Vector2(0, accelerator.JumpAccelerator(accB, jumpTime));
    }
}
