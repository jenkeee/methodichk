using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class turrelFire : MonoBehaviour
{
    public GameObject player;
    public Transform Player;


    Vector3 PlayerPos;

    bool findEnemy;
    bool lostEnemy;
    // Start is called before the first frame update
    public static void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {

            if (other.gameObject == player)
            {
            findEnemy = true; 
            }
         
    }
    void Update()
    {
        PlayerPos = player.transform.position;
        Vector3 direction = PlayerPos - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction,  Time.deltaTime, 0);
        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycastHit;
        if (findEnemy) { 
        if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == Player)
                {
                    patrul.FindEnemy();
                }
            }
        }
    }

        private void OnTriggerExit(Collider other)
    {
        
                if (other.gameObject == player )
                {
            findEnemy = false;
                    patrul.LostEnemy();
                }
       
    }
}
