using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


    public class Pistol : MonoBehaviour
    {
        public GameObject player;

        public AudioSource getPistol;

        bool m_HasAudioPlayed;
        bool m_IsPlayerGetPistol;

        public CanvasGroup PistolImage;
        float m_Timer;

        [Tooltip("—юда ложим камеру которую выключим")]
        public UnityEngine.Object camera_off;
        [Tooltip("—юда ложим камеру которую выключим")]
        public UnityEngine.Object camera_on;

        [Tooltip("—юда требуетьс€ положить объект который исчезнет когда лемон его возмет")]
        public UnityEngine.Object m_PlasmaGun;
        [Tooltip("—юда требуетьс€ положить объект пистоли")]
        public UnityEngine.Object m_MyPistol;

        [Tooltip("—юда требуетьс€ положить канвас с прицелом 3пс")]
        [SerializeField]
        private Canvas thirdPersonCanvas;



    void Start()
        {

        }
        void OnTriggerEnter(Collider otherCollider)
        {

            if (otherCollider.gameObject == player)
            {
         
                m_IsPlayerGetPistol = true;
                thirdPersonCanvas.enabled = true;


                if (camera_off != null)
                {
                    GameObject targetGameObject = camera_off as GameObject;
                    Behaviour targetBehaviour = camera_off as Behaviour;
                    GameObject obgCamera_on = camera_on as GameObject;
                    obgCamera_on.SetActive(true);
                    if (targetBehaviour != null)
                        targetGameObject = targetBehaviour.gameObject;
                    if (targetGameObject != null)
                        targetGameObject.SetActive(false);
                }
                Object currentItem = m_PlasmaGun;
                if (currentItem != null)
                {
                    GameObject targetGameObject = currentItem as GameObject;

                    //Behaviour targetBehaviour = currentItem as Behaviour;
                    // if (targetBehaviour != null)
                    //     targetGameObject = targetBehaviour.gameObject;
                    if (targetGameObject != null)
                        targetGameObject.SetActive(false);
                }
                Object MyPistol = m_MyPistol;
                if (MyPistol != null)
                {
                    GameObject targetGameObject = MyPistol as GameObject;
                    if (targetGameObject != null)
                        targetGameObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.Locked;
                }

            }
        }


        void Update()
        {

            if (m_IsPlayerGetPistol)
            {
                GetPistol(PistolImage, getPistol);
                //gameObject.SetActive(false);
            }

        }

        void GetPistol(CanvasGroup iamgePistol, AudioSource audioSource)
        {
            if (!m_HasAudioPlayed)
            {
                audioSource.Play();
                m_HasAudioPlayed = true;
            }
            m_Timer += Time.deltaTime;  // нехочу чтоб моменталоьно картинка пистол€ по€вл€лась        
            iamgePistol.alpha = m_Timer / 2; // 
        }
    }

