using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage = 50;
    public GameObject impactEffect;
    public AudioSource bulletOut;

    

    public void Seek(Transform _target){
        target = _target;

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null){
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();

            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        
    }

    void Damage(Transform enemy){
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null){
          e.TakeDamage(damage);
          bulletOut.Play(); 
        }
        
    }

    void HitTarget(){
        
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
        Damage(target);
    }
}
