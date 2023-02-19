using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    bool check = false;
    public int enemyHealth = 100;

    private Transform target;
    private int wavepointIndex = 0;
    

    void Start(){
        target = Waypoint.points[0];
    }

    public void TakeDamage(int amount){
        enemyHealth -= amount;

        if(enemyHealth < 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    void Update(){
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f){
            GetNextWayPoint();
        }
        SpeedUp();
        Debug.Log(speed);
        
    }

    void GetNextWayPoint(){

        if(wavepointIndex >= Waypoint.points.Length - 1){
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }
    void EndPath(){
        HealthSystem.healthCount--;
        Destroy(gameObject);
    }

    void SpeedUp(){        
        if (HealthSystem.countRounds%20 == 0 && check == false){
            speed += 15;
            check = true;
         
        }
        if(HealthSystem.countRounds%5 != 0){
            check = false;
        }
        

    }

   
}
