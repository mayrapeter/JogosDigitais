using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuPrincipal : MonoBehaviour
{
    GameManager gm;
    public GameObject purpleShip;
    public GameObject staticEnemy;
    public GameObject EnemySprite;
    public GameObject player;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }
    
    public void Comecar()
    {
        purpleShip.SetActive(true);
        staticEnemy.SetActive(true);
        EnemySprite.SetActive(true);
        player.SetActive(true);
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
