using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulhaWaypoints : State
{
    SteerableBehaviour steerable;

    public Transform[] waypoints;
    
    public override void Awake()
    {
        base.Awake();

        Transition Atacando = new Transition();
        Atacando.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform, 2.0f);
        Atacando.target = GetComponent<StateAtaque>();
        transitions.Add(Atacando);
        steerable = GetComponent<SteerableBehaviour>();
    }

    public void Start()
    {
        waypoints[0].position = transform.position;
        waypoints[1].position = GameObject.FindWithTag("Player").transform.position;

    }


    public void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[1].position) > 0.1f)
        {
            Vector3 direction = waypoints[1].position - transform.position;
            direction.Normalize();
            steerable.Thrust(direction.x, direction.y);
        } else
        {
            waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
        }
        
       
    }
}
