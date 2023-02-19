using UnityEngine;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour
{
    //Ronds Counts
    public static int countRounds = 0; 
    //The UI text for the health count    
    public Text txt_healthCount;
    //The default value of the health count (used for initiating)
    public int defaultHealthCount;
    //Curent health count
    public static int healthCount;
    //Initiate the health System (reset the health count)
    public void Init(){
        healthCount = defaultHealthCount;
        txt_healthCount.text = healthCount.ToString();

    }
    //lose the health count
    public void LoseHealth(){
        if (healthCount < 1)
            return;
            
        healthCount--;
        txt_healthCount.text = healthCount.ToString();

        CheckHealthCount();
    }
    //Checkk game for losing 
    void CheckHealthCount(){
        if (healthCount<1){
            Debug.Log("You Losing");
            //Call some reset value and stopp the game manager
        }
    }

    void Start()
    {
        InvokeRepeating("CheckHealth", 0f, .2f);
    }
    public void CheckHealth()
    {       if (healthCount < 0)
                return;
            txt_healthCount.text = healthCount.ToString();
        
        
    }

    
}
