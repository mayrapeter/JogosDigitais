using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject shot;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    
    public void Shoot()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (gm.pontos >= 3 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

    
}
