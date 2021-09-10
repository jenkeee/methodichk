using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnControllerColliderHit.html
public class t_grd : MonoBehaviour
{
    [SerializeField] private int speed;

    double time_avoid = 50;
    [Tooltip("врем€ через которое начнет обрабатыватьс€ колизи€")]
    [SerializeField] double time_avoid_in = 50;
    bool readyTo = false;

   // public Explode myForit; // экземпл€р класса
        public GameObject srapnel;   
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
    public float radius = 5.0F;
    public float power = 10.0F;
    void Start()
    {
       
    }
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
                { /*
                    GameObject temp = Instantiate(srapnel, gameObject.transform.position, Quaternion.identity);
                    Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                    tempRB.AddExplosionForce(power, gameObject.transform.position, radius, 3.0F);
                    Destroy(temp, 5f);
*/

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
        Explode.Notrdy_Explosion();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Trka"))
        {
            /*int i;
            for (i=0;i<2;i++)
            {*/
            /* GameObject temp = Instantiate(srapnel, gameObject.transform.position, Quaternion.identity);
             Rigidbody tempRB = temp.GetComponent<Rigidbody>();
             tempRB.AddExplosionForce(power, gameObject.transform.position, radius, 3.0F);
             Destroy(temp, 1f);*/
            Explode.rdy_Explosion();
            readyTo = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Trka"))
            readyTo = true;
    }

}

