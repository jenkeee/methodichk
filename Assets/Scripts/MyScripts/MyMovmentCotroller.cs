using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class MyMovmentCotroller : MonoBehaviour
    {
        private float turnSpeed = 50f;
        public float playerSpeed = 3f;
        public float RotateAtLook = 30f;
        bool HasInput;

        Animator m_Animator;
        Rigidbody m_Rigidbody;
        AudioSource m_AudioSource;
        Vector3 m_Movement;
        Quaternion m_Rotation = Quaternion.identity;


        [SerializeField]
        [Tooltip("Можем установить силу прыжка")]
        private float jumpPower;

        public bool isGrounded = true;

        
        public bool hasKey = false;

       

        private void OnCollisionEnter(Collision collision)
        {
            isGrounded = true;
        }


        private Transform cameraTransform; // будем поворачивать лемона

        private void Awake()
        {
            cameraTransform = Camera.main.transform;
        }
        void Start()
        {
            m_Animator = GetComponent<Animator>();
            m_Rigidbody = GetComponent<Rigidbody>();
            m_AudioSource = GetComponent<AudioSource>();
        }

        private void LateUpdate()
        {

        }

        void FixedUpdate()
        {
            float X = Input.GetAxis("Horizontal");
            float Z = Input.GetAxis("Vertical");

            /// направим лемона в сторону камеры ////////////////
            Vector2 input = new Vector2(X, Z);
            Vector3 move = new Vector3(input.x, 0, input.y);
            move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
            m_Movement.Set(move.x, 0f, move.z);
            m_Movement.Normalize();
            //////////////////////////////////////////////////////////////////
            bool hasHorizontalInput = !Mathf.Approximately(X, 0f);
            bool hasVerticalInput = !Mathf.Approximately(Z, 0f);
            bool isWalking = hasHorizontalInput || hasVerticalInput;
            m_Animator.SetBool("IsWalking", isWalking);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isGrounded = false;
                // GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPower * 1000, 0));
                Vector3 jump = new Vector3(0, jumpPower * 1000, 0);
                m_Rigidbody.AddRelativeForce(jump, ForceMode.Force);
            }
            m_Animator.SetBool("IsJump", !isGrounded);
            // отключил анимацию чтоб лемон летал нормально. я думаю это связанно с массой ригитбади

            if (isWalking && isGrounded)
            {
                if (!m_AudioSource.isPlaying)
                {
                    m_AudioSource.Play();
                }
            }
            else
            {
                m_AudioSource.Stop();
            }

            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
            // Rotate toward camera direction.       
            if (!isWalking)
            {
                Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotateAtLook * Time.deltaTime);
            }
        }

        void OnAnimatorMove()
        {
            m_Rigidbody.MovePosition(m_Rigidbody.position + (m_Movement * playerSpeed) * m_Animator.deltaPosition.magnitude);
            m_Rigidbody.MoveRotation(m_Rotation);
        }

    }
