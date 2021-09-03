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

        [Tooltip("���� ����� ������ ������� ��������")]
        public UnityEngine.Object camera_off;
        [Tooltip("���� ����� ������ ������� ��������")]
        public UnityEngine.Object camera_on;

        [Tooltip("���� ���������� �������� ������ ������� �������� ����� ����� ��� ������")]
        public UnityEngine.Object m_PlasmaGun;
        [Tooltip("���� ���������� �������� ������ �������")]
        public UnityEngine.Object m_MyPistol;

        [Tooltip("���� ���������� �������� ������ � �������� 3��")]
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
            m_Timer += Time.deltaTime;  // ������ ���� ������������ �������� ������� ����������        
            iamgePistol.alpha = m_Timer / 2; // 
        }
    }

