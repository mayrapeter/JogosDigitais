using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : SteerableBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }
    private void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        Thrust(1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) return;
        IDamageable damegeable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damegeable is null))
        {
            gm.pontos++;
            damegeable.TakeDamage();
        }
        gameObject.SetActive(false);
        // Destroy(gameObject);
        
    }
}
