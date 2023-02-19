using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{    
    

    //Transform of the spawning towers (Root Object)
    public Transform spawnTowerRoot; 
    //list of tower (prefabs) that will instatiate
    public List<GameObject> towersPreFabs;
    //list of tower UI
    public List<Image> towersUI;

    //id tower to spawn
    int spawnID = -1;
    
    //SpawnPoint Tilemap
    public Tilemap spawnTilemap;

    void Update(){
        if(CanSpawn())
        DetectSpawnPoint();
        
    }

    bool CanSpawn(){
        if(spawnID == -1)
            return false;
        else 
            return true;
    }

    void DetectSpawnPoint(){ 
        //detect mouse when clicked (first touch clicked)
        if(Input.GetMouseButtonDown(0)){

        
            //get the world space position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            
            //get the center position of the cell
            var cellPostCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            //get if we can spawn in that cell (collider)
            if(spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite){
                int towerCost = TowerCost(spawnID);
                
                //Check if currency is enough to spawn
                if(GameManager.instance.currency.EnoughCurrency(towerCost)){
                //Use the amount of cost from the currency available
                GameManager.instance.currency.Use(towerCost);
                //Spawn Tower
                SpawnTower(cellPostCentered);
                //Disable Tower
                spawnTilemap.SetColliderType(cellPosDefault,Tile.ColliderType.None);
                }else{
                    Debug.Log("Not Enough Currency");

                }
            }           
        } 
    }
    public int TowerCost(int id){

        switch(id){
            case 0: return towersPreFabs[id].GetComponent<Tower_Lvl1>().cost;
            case 1: return towersPreFabs[id].GetComponent<Tower_Lvl2>().cost;
            case 2: return towersPreFabs[id].GetComponent<Tower_Lvl3>().cost;
            default: return -1;
        }
    }

    void SpawnTower(Vector3 position){
        GameObject tower = Instantiate(towersPreFabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;

        DeselectTowers();
    }

    public void SelectTower(int id){
        DeselectTowers();
        //Set spawn ID
        spawnID = id;
        //Highlight the tower
        towersUI[spawnID].color = Color.white;

    }

    public void DeselectTowers(){
        spawnID = -1;
        foreach(var t in towersUI){
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    
}
