using System;
using UnityEngine;

 class Accelerator
{
    float t, y = 0;
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

    public float JumpAccelerator(float b, float t)
    {
        y = (1-2*b)*(t*t)+(2*b)*t;
        return y * Time.fixedDeltaTime;
    }

    public float FallAccelerator(float b, float t)
    {
        y = (1 - 2 * b) * ((t+1) *(t+1)) + (2 * b) * (t + 1);
        return y * Time.fixedDeltaTime / 10;
    }
}
