using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    //FIELDS
    //Currency txt UI
    public Text txt_Currency;
    //default currency value
    public int defaultCurrency;
    //curret currency value
    public int currency;

    float timer = 0f;
    public float moneyTimer;

    //METHODS
    //Init (reset the default value)
    public void Init(){
        currency = defaultCurrency;
        UpdateUI();
    }
    //Gain currency (input of value)
    public void Gain(int val){
        currency += val;
        UpdateUI();
    }
    //Use currency (input of value)
    public bool Use(int val){
        if(EnoughCurrency(val)){
            currency -= val;
            UpdateUI();
            return true;

        }else{
            return false;
        }

    }
    //Check availability of currency
    public bool EnoughCurrency(int val){
        //Check if the val is equal or more than currency
        if(val <= currency)
            return true;
        else 
            return false;
    }
    //Update txt UI

    void UpdateUI(){
        txt_Currency.text = currency.ToString();
    }

    public void USE_TEST(){
        Debug.Log(Use(3));
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = moneyTimer;
            currency += 2;
        
        }
        UpdateUI();
    }
}
