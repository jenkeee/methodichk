using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRayPistol : MonoBehaviour
{
    public GameObject pistolOut;
    public GameObject pistolIn;
    public AudioSource pickUp;

    [Tooltip("���� ����� ������ ������� ��������")]
    public GameObject camera_off;
    [Tooltip("���� ����� ������ ������� ��������")]
    public GameObject camera_on;

    bool m_HasAudioPlayed; // ��� ����� ��������� �� �������������� ���������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
            pistolOut.SetActive(false);
            pistolIn.SetActive(true);
            camera_off.SetActive(false);
            camera_on.SetActive(true);
            if (!m_HasAudioPlayed)
            {
                pickUp.Play();
                m_HasAudioPlayed = true;
                ShootPistol.HasPistol();
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
