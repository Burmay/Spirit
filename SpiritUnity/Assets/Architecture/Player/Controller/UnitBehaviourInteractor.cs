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
    }

    public Vector2 HorisonMove(float currentSpeed, float maxSpeed, int dir, float timeAcc)
    {
        if(Math.Abs(currentSpeed) >= maxSpeed)
        {
            return new Vector2(0,0);
        }
        else
        {
            return new Vector2(accelerator.Acceleration(timeAcc, maxSpeed, currentSpeed, dir),0);
        }
    }

    public Vector2 Fall()
    {
        return new Vector2(0, 4 * Time.fixedDeltaTime);
    }

    public Vector2 Jump()
    {
        //return new Vector2(accelerator.Acceleration(timeAcc, maxSpeed, currentSpeed, dir), 0);
        return new Vector2(0, 3 * Time.fixedDeltaTime);
    }
}
