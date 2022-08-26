using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitBehaviourInteractor : Interactor
{
    GameObject girlTag, tankTag, warriorTag, shooterTag, unitBaseTag;
    GirlsActionsController girl;
    TankActionsController tank;
    ShooterActionsController shooter;
    WarriorActionsController warrior;
    UnitBase unitBase;

    Accelerator accelerator;

    public override void OnCreate()
    {
        base.OnCreate();
        unitBaseTag = GameObject.FindGameObjectWithTag("BaseUnit");
        girlTag = GameObject.FindGameObjectWithTag("Girl");
        tankTag = GameObject.FindGameObjectWithTag("Tank");
        warriorTag = GameObject.FindGameObjectWithTag("Warrior");
        shooterTag = GameObject.FindGameObjectWithTag("Shooter");

        unitBase = unitBaseTag.GetComponent<UnitBase>();
        girl = girlTag.GetComponent<GirlsActionsController>();
        tank = tankTag.GetComponent<TankActionsController>();
        warrior = warriorTag.GetComponent<WarriorActionsController>();
        shooter = shooterTag.GetComponent<ShooterActionsController>();


        accelerator = new Accelerator();
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

    public void ActivePerson()
    {

    }

    public void Fall()
    {

    }

    public void Jump()
    {

    }
}
