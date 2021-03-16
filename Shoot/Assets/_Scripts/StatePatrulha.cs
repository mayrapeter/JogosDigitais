using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulha : State
{
    SteerableBehaviour steerable;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    
    public override void Awake()
    {
        base.Awake();

        Transition Atacando = new Transition();
        Atacando.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform, 2.0f);
        Atacando.target = GetComponent<StateAtaque>();
        transitions.Add(Atacando);
        steerable = GetComponent<SteerableBehaviour>();
    }

    float angle = 0;

    public void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        steerable.Thrust(x, y);
       
    }
}
