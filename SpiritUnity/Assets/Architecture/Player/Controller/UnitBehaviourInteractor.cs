using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviourInteractor
{
    GameObject girlTag, tankTag, warriorTag, shooterTag;
    GirlsActionsController girl;
    TankActionsController tank;
    ShooterActionsController shooter;
    WarriorActionsController warrior;


    public void Initialeze()
    {
        girlTag = GameObject.FindGameObjectWithTag("Girl");
        tankTag = GameObject.FindGameObjectWithTag("Tank");
        warriorTag = GameObject.FindGameObjectWithTag("Warrior");
        shooterTag = GameObject.FindGameObjectWithTag("Shooter");

        girl = girlTag.GetComponent<GirlsActionsController>();
        tank = girlTag.GetComponent<TankActionsController>();
        warrior = girlTag.GetComponent<WarriorActionsController>();
        shooter = girlTag.GetComponent<ShooterActionsController>();
    }

    public float HorisonMove(float currentSpeed, float maxSpeed, int dir, float timeAcc)
    {
        if(currentSpeed >= maxSpeed)
        {
            return 0;
        }
        else
        {
            return 0; //Del
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
