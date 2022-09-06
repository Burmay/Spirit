using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyBase
{

    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        base.HP = 1;
        base.maxSpeed = 3;
        base.timeAcc = 0.2f;
        currentSpeed = default;

        GetLink();
    }

    void Update()
    {
        base.StateMachine();
    }

    protected override void Fall()
    {
        rigidbody.position += unitBehaviourInteractor.Fall(fallTime, fallB);
    }
}
