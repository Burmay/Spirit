using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwichier : MonoBehaviour
{
    GameObject girlTag, tankTag, warriorTag, shooterTag;
    GirlsActionsController girl;
    TankActionsController tank;
    ShooterActionsController shooter;
    WarriorActionsController warrior;

    UnitBase[] units;
    int active;

    private void Start()
    {
        units = new UnitBase[4];
        girlTag = GameObject.FindGameObjectWithTag("Girl");
        tankTag = GameObject.FindGameObjectWithTag("Tank");
        warriorTag = GameObject.FindGameObjectWithTag("Warrior");
        shooterTag = GameObject.FindGameObjectWithTag("Shooter");

        girl = girlTag.GetComponent<GirlsActionsController>();
        tank = tankTag.GetComponent<TankActionsController>();
        warrior = warriorTag.GetComponent<WarriorActionsController>();
        shooter = shooterTag.GetComponent<ShooterActionsController>();

        units[0] = girl;
        units[1] = tank;
        units[2] = warrior;
        units[3] = shooter;

        girl.active = true;
        active = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            Deactivate();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                active--;
                CorrectActive();
                units[active].active = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                active++;
                CorrectActive();
                units[active].active = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                girl.active = true;
                active = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                tank.active = true;
                active = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                warrior.active = true;
                active = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                shooter.active = true;
                active = 3;
            }
        }
    }

    private void Deactivate()
    {
        foreach (UnitBase unit in units)
        {
            unit.active = false;
        }
    }

    private void CorrectActive()
    {
        if(active > 3)
        {
            active = 0;
        }
        if(active < 0)
        {
            active = 3;
        }
    }
}
