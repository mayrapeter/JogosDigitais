using UnityEngine;
using UnityEngine.UI;
public class UI_Fim : MonoBehaviour
{
   public Text message;
   public GameObject purpleShip;
   public GameObject staticEnemy;
   public GameObject EnemySprite;
   public GameObject player;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if(gm.vidas > 0)
        {
            message.text = "Você Ganhou!!!";
        }
        else
        {
            message.text = "Você Perdeu!!";
        }
    }
    public void Voltar()
    {
        purpleShip.SetActive(true);
        staticEnemy.SetActive(true);
        EnemySprite.SetActive(true);
        player.SetActive(true);
        gm.ChangeState(GameManager.GameState.GAME);
    }
}