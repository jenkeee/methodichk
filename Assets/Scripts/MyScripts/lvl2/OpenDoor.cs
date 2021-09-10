using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject player;
    [Tooltip("Сюда звук при колизии")]
    public AudioSource DoorIsOpen;

    bool m_HasAudioPlayed;
    bool m_IsPlayerGetKey;


    [Tooltip("Сюда ложим что исчезнет")]
    public UnityEngine.Object[] objOut;
    [Tooltip("Сюда ложим что появится")]
    public UnityEngine.Object objIn;


    void OnTriggerEnter(Collider otherCollider)
    {

        if (otherCollider.gameObject == player)
        {

            m_IsPlayerGetKey = true;

            int index = 0;
            for (index = 0; index < objOut.Length; index++)
            { Object currentItem = objOut[index];
                if (currentItem != null)
                {
                    GameObject targetGameObject = currentItem as GameObject;

                    if (targetGameObject != null)
                        targetGameObject.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {

        if (m_IsPlayerGetKey)
        {
            DoOpenDoor(DoorIsOpen);
            //gameObject.SetActive(false);
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
