using System;
using UnityEngine;

class Accelerator
{
    // super
    public float Acceleration(float accTime, float maxSpeed, float momentSpeed, int dir)
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
            }
        }
        else
        {
            currentSpeed = 0;
        }
        if(dir > 0)
        {
            return currentSpeed;
        }
        else
        {
            return -currentSpeed;
        }
    }
}
