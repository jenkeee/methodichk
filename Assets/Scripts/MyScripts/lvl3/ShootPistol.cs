using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPistol : MonoBehaviour
{
    static bool hasPistolSmall = false;
    //public Transform barell;
    Vector3 ShootPos;
    private Transform cameraTransform;


    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && hasPistolSmall)
        {
            Cursor.lockState = CursorLockMode.Locked;
            //Debug.Log("pistol Click");


            Vector3 direction = Camera.main.transform.forward;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;


            if (Physics.Raycast(transform.position, direction, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("Enemy") ^ raycastHit.collider.CompareTag("Player"))
                {
                    MyEnemy.Hurt2(100);
                    Debug.Log("Попадание");
                }
            }

        }
    }
        
    

    public static void HasPistol()
    { hasPistolSmall = true; }
}
