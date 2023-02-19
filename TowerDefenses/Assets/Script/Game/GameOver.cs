 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public Text roundText;
  void OnEnable (){
    roundText.text = (HealthSystem.countRounds.ToString() + " Round Survived");
    HealthSystem.countRounds = 0;

  }

  public void Retry(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

  }

  public void Menu(){
    SceneManager.LoadScene(0);
  }


}
