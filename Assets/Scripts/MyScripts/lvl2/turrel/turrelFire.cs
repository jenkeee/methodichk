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
    int auto_fire;
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
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            auto_fire = 100; ;
        }

    }
    void Update()
    {
        auto_fire -= 1;

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
                    if (auto_fire <=0)
                    t_shooting.FindEnemy();
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
            t_shooting.LostEnemy();
                }
       
    }
}
