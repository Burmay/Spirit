using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.GetComponent<Rigidbody2D>();
        base.HP = 3;
        this.maxSpeed = 1;
        base.timeAcc = 1f;
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
