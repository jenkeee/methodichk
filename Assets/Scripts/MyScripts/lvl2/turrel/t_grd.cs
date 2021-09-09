using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnControllerColliderHit.html
public class t_grd : MonoBehaviour
{
    [SerializeField] private int speed;

    double time_avoid = 50;
    [Tooltip("время через которое начнет обрабатываться колизия")]
    [SerializeField] double time_avoid_in = 50;
    bool readyTo = false;
    /*private void 
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<MyEnemy>();
            enemy.Hurt(_pistolDMG);
            Destroy(gameObject);
        }
    }*/


    /* private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Enemy"))
         {
             var enemy = other.GetComponent<MyEnemy>();
             enemy.Hurt(pistolDMG);            
             //Destroy(gameObject);
             //gameObject.SetActive(false);
         }
     }*/
    void Update()
    {
        if (gameObject)
        {
            
            if (time_avoid > 0)
            {
                time_avoid -= 1;
                readyTo = false;
            }            
            else if (time_avoid == 0)
            {
                if (readyTo)
                {
                    gameObject.SetActive(false);
                }                
            }
        }

    }
    private void OnEnable()
    {
        time_avoid = time_avoid_in;
    }
    private void OnDisable()
    {
      
    }
    private void OnCollisionEnter(Collision collision)
    {
            readyTo = true;        
    }
    private void OnCollisionStay(Collision collision)
    {
        readyTo = true;
    }
}

