using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBehavior : SteerableBehaviour
{
    Vector3 direction;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Inimigo")) return;
        IDamageable damegeable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damegeable is null))
        {
            damegeable.TakeDamage();
        }
        gameObject.SetActive(false);
        // Destroy(gameObject);
        
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
        Thrust(direction.x, direction.y);
        
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
