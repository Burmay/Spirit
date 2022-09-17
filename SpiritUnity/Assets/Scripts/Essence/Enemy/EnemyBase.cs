using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Essence
{
    protected void StateMachine()
    {
        if (unitBehaviourInteractor.onCreate == true)
        {
            if (isGrounded == false) { fallTime += Time.fixedDeltaTime; Fall(); }
            if (isGrounded == true) { fallTime = default; }
        }
    }

    protected override void Fall()
    {
        
    }
}
