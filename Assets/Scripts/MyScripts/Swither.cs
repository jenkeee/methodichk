using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Swither : MonoBehaviour
{
    [Tooltip("—юда ложим камеру которую выключим")]
    public UnityEngine.Object camera3ps;
    [Tooltip("—юда ложим камеру которую выключим")]
    public UnityEngine.Object cameraAim;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
    }
    // Update is called once per frame
    void Update()
    {
        GameObject AimCamera = cameraAim as GameObject;
        GameObject ThirdPerson = camera3ps as GameObject;
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            AimCamera.SetActive(true);
            ThirdPerson.SetActive(false);
        }

        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ThirdPerson.SetActive(true);
            AimCamera.SetActive(false);
        }
    }
    private void LateUpdate()
    {
       
    }
}
