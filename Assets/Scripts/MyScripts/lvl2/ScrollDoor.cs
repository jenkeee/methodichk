using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDoor : MonoBehaviour
{
    public GameObject player;
    [Tooltip("Сюда звук при колизии")]
    public AudioSource DoorIsOpen;

    bool m_HasAudioPlayed;

    [Tooltip("Сюда ложим что поедет")]
    public Transform doorPos;
    Vector3 DoorPos;

    bool door_open = false;

    private void Awake()
    {
        DoorPos = doorPos.transform.position;
    }

    void OnTriggerEnter(Collider otherCollider)
    {

        if (otherCollider.gameObject == player)
        { 
            DoOpenDoor(DoorIsOpen);
            door_open = true;            
        }
    }
          /*
            int index = 0;
            for (index = 0; index < objOut.Length; index++)
            { 
                Object currentItem = objOut[index];

                Vector3 direction =;
                if (currentItem != null && currentItem(transform.position))
                {
                    DoorPos.position.x -= Time.deltaTime;

                    if (targetGameObject != null)
                        targetGameObject.transform.position.x = ;
                }
            }
           // Object currentItem = objOut;

            

            Object item = objIn;
            if (item != null)
            {
                GameObject targetGameObject = item as GameObject;
                if (targetGameObject != null)
                    targetGameObject.SetActive(true);
            }

        }
    }
*/
    // Update is called once per frame
    void Update()
    {
        if (door_open && doorPos.position.y > -6)
        {
            DoorPos.y -= Time.deltaTime;
            //doorPos.transform.position = Vector3.Lerp(doorPos.transform.position, new Vector3(-10f, 0f, 0f), Time.deltaTime * 1);
            doorPos.transform.position = DoorPos;
        }
    
    }
    void DoOpenDoor(AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        /*
        m_Timer += Time.deltaTime;  // Такой таймер могу везде применить       
        iamgePistol.alpha = m_Timer / 2; // */
    }
}
