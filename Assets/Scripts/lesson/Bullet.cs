using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnControllerColliderHit.html
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _pistolDMG;

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
 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<MyEnemy>();
            enemy.Hurt(_pistolDMG);            
            //Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}

