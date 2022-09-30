using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwichier : MonoBehaviour
{
    GameObject girlTag, tankTag, warriorTag, shooterTag;
    [SerializeField] GirlsActionsController girl;
    [SerializeField]  TankActionsController tank;
    [SerializeField] ShooterActionsController shooter;
    [SerializeField] WarriorActionsController warrior;

    UnitBase[] units;
    private int active;

    private void Start()
    {
        units = new UnitBase[4];

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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Deactive(active);
                active--;
                CorrectActive();
                units[active].active = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Deactive(active);
                active++;
                CorrectActive();
                units[active].active = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Deactive(active);
                girl.active = true;
                active = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Deactive(active);
                tank.active = true;
                active = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Deactive(active);
                warrior.active = true;
                active = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Deactive(active);
                shooter.active = true;
                active = 3;
            }
        }
    }

    private void Deactive(int prevActive)
    {
        units[prevActive].Swich();
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
