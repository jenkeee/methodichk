using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class turrelFire : MonoBehaviour
{
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    { 
        if (other.gameObject == player) { 
            
            patrul.FindEnemy();
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
        
            patrul.LostEnemy();
        }
    }
}
