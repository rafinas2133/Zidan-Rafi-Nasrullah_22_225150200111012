using UnityEngine;

public class CostDisplayer : MonoBehaviour
{
   //FIELDS
   //Towerr ID
   public int towerID;
   //Cost Value
   public int towerCost;
   
   //Methods
   //Init (Fetch the value from the spawner tower list)
    void Start(){
        towerCost = GameManager.instance.spawner.TowerCost(towerID);
        GetComponent<UnityEngine.UI.Text>().text = towerCost.ToString();

    }
}
