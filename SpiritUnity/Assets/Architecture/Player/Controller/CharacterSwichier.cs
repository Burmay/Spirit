using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwichier : MonoBehaviour
{
    enum Character
    {
        Girl = 0,
        Tank = 1,
        Warrior = 2,
        Shooter = 3
    }

    int[] arrayCharacter;
    int choiseCharacter;

    private void Start()
    {
        arrayCharacter = new int[3];
        arrayCharacter[0] = 0;
        arrayCharacter[1] = 1;
        arrayCharacter[2] = 2;
        arrayCharacter[3] = 3;
        choiseCharacter = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if(choiseCharacter > 0)
            {
                choiseCharacter = arrayCharacter[choiseCharacter - 1];
            }
            else
            {
                choiseCharacter = 3;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (choiseCharacter < 3)
            {
                choiseCharacter = arrayCharacter[choiseCharacter + 1];
            }
            else
            {
                choiseCharacter = 0;
            }
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {

        }
        if (Input.GetKey(KeyCode.Alpha4))
        {

        }
    }
}
