using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public static bool GameIsOver;
   public GameObject gameOverUI;

   
   void Awake(){instance = this;}

   public Spawner spawner;
   public HealthSystem health;
   public CurrencySystem currency;

   void Start(){
    GetComponent<HealthSystem>().Init();
    GetComponent<CurrencySystem>().Init();
    GameIsOver = false;
   }

   void Update(){
      if(GameIsOver)
         return;
      
      if(Input.GetKeyDown(KeyCode.Escape)){
         EndGame();
      }

      if (HealthSystem.healthCount <= 0){
         EndGame();
      }
   }

   void EndGame(){
      GameIsOver = true;
      gameOverUI.SetActive(true);
   }
}
