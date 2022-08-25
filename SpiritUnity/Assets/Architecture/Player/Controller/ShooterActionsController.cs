using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.GetComponent<Rigidbody2D>();
        base.HP = 1;
        base.maxSpeed = 1.5f;
        base.timeAcc = 0.7f;
        currentSpeed = default;
    }

    public override void SetLink(UnitBehaviourInteractor unitBehaviourInteractor)
    {
        base.SetLink(unitBehaviourInteractor);
    }

    void Update()
    {
        
    }
}
