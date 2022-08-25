using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlsActionsController : UnitBase
{
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.GetComponent<Rigidbody2D>();
        base.HP = 3;
        base.maxSpeed = 3;
        base.timeAcc = 0.2f;
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
