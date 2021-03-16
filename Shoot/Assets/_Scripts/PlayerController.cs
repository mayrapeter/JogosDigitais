using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  
    Animator animator;
    public GameObject bullet;
    public Transform gun;
    public float shotDelay = 1.0f;
    
    public AudioClip shotSoundEffects;
    GameManager gm;

    private float _lastShootTimestamp = 0.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        if(Time.time - _lastShootTimestamp < shotDelay) return;
        AudioManager.PlaySoundEffects(shotSoundEffects);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, gun.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        gm.vidas--;
        if (gm.vidas <= 0) Die();
    }

    public void Die()
    {
        // Destroy(gameObject);
        gm.ChangeState(GameManager.GameState.ENDGAME);
    }

    void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (gm.pontos >= 3 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        if (gm.gameState != GameManager.GameState.GAME) return;
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);

        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocidade", 1.0f);
        } else 
        {
            animator.SetFloat("Velocidade", 0.0f);   
        }

        if (Input.GetAxisRaw("Jump") != 0)
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

        Debug.Log($"State: {gm.gameState} ");
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            gm.pontos++;
            collision.gameObject.SetActive(false);
            // Destroy(collision.gameObject);
            TakeDamage();
        }
    }


    
}
