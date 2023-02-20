using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void QuitBtn(){
        Application.Quit();
    }

    public void HowPlayBtn(){
        SceneManager.LoadScene(2);
    }
    public void BackHowPlayBtn(){
        SceneManager.LoadScene(0);
    }
}
