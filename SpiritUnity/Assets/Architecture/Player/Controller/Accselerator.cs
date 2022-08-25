using System;
using UnityEngine;

class Accelerator
{
    // super
    public static float Acceleration(float accTime, float maxSpeed, float momentSpeed)
    {
        float currentSpeed;
        if (Math.Abs(accTime) > Double.Epsilon)
        {
            if (momentSpeed < maxSpeed)
            {
                currentSpeed = Time.deltaTime / accTime;
            }
            else
            {
                currentSpeed = Time.deltaTime / accTime;
                //if (momentSpeed < 0) momentSpeed = 0;
            }
        }
        else
        {
            currentSpeed = 0;
        }




        return momentSpeed;
    }
}
}
