using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Tooltip("������ ����")]
    public GameObject MyMine;
    [SerializeField]
    [Tooltip("���� ��� ���� ���� ���������")]
    private Transform bulletPoolTr;
    [Tooltip("� ������� ������ ������� ��������� ������� ")]
    public Transform ShootingPoint; // ����� �������� ����
    [Tooltip("� ������� ������ ������� ��������� ����")]
    public Transform MinePoint; // ����� �������� ���

    public float bulletSpeed = 500;

    [Tooltip("���������� � ���������� ���������")]
    public Transform PlayerTransform;
    [Tooltip("���������� � ���������� ���������")]
    public Rigidbody PlayerRigidbody;

    private Transform cameraTransform;


    public Vector3 target { get; set; }
    public bool hit { get; set; }


    int currentBulletIndex = 0;
    int toDisable;



    public bool hasPistol = false;
    public bool hasKey = false;
    bool flag_key = false;

    bool m_playerHasPistol = false;
    [Tooltip("���� ���������� �������� ������ �� �������� ����� �� �������")]
    public UnityEngine.Object m_PlasmaGun;
    [Tooltip("���� ���������� �������� ������ ������� � ����")]
    public UnityEngine.Object m_MyPistol;
    [Tooltip("���� ���������� �������� ������ MyItem ��� � ������ ����")]
    public Transform m_MyItem;
    [Tooltip("���� ���������� �������� ����� ��� � ������ ����")]
    public Transform m_Key;
    [Tooltip("���� ���������� �������� ������ �� �������� ����� �� ������� (�����)")]
    public Object collision_key;

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody>(); // ���������� � ���������� ���������
        PlayerTransform = transform; // ���������� � ���������� ��������� ������� �� �������
    }

    // Start is called before the first frame update
    void Start()
    {

    }/*
    private static void DisappearanceLogic(GameObject gameObject)
    {
        int num = 0;
        while (num >= 0)
        {
            if (num % 2 == 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
            num++;
        }
    }*/
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject == m_PlasmaGun)
        { m_playerHasPistol = true; hasPistol = true; }
        else if (otherCollider.gameObject == collision_key)
        { flag_key = true; hasKey = true; }

    }

    public void GetMyKey()
    {
        hasKey = true;
    }

    void Update()
    {
        Object MyPistol = m_MyPistol;
        if (flag_key)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (hasKey)
                {
                    hasPistol = false;
                    hasKey = false;
                    for (int i = 0; i < m_MyItem.childCount; i++)
                        m_MyItem.GetChild(i).gameObject.SetActive(false);
                }
                else if (!hasKey)
                {
                    for (int i = 0; i < m_MyItem.childCount; i++)
                        m_MyItem.GetChild(i).gameObject.SetActive(false);
                    hasPistol = false;
                    hasKey = true;
                    m_Key.gameObject.SetActive(true);
                }

            }
        }
        if (m_playerHasPistol)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (hasPistol)
                {
                    hasPistol = false;
                    GameObject targetGameObject = MyPistol as GameObject;
                    if (targetGameObject != null)
                        targetGameObject.SetActive(false);

                    for (int i = 0; i < m_MyItem.childCount ; i++)
                        m_MyItem.GetChild(i).gameObject.SetActive(false);
                   
                }
                else if (!hasPistol)
                {
                    hasPistol = true;
                    for (int i = 0; i < m_MyItem.childCount; i++)
                        m_MyItem.GetChild(i).gameObject.SetActive(false);
                    GameObject targetGameObject = MyPistol as GameObject;
                    if (targetGameObject != null)
                        targetGameObject.SetActive(true);
                }

            }
            
        }


        if (m_playerHasPistol)
        {
            if (hasPistol)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    #region ������ ���� � �������� � 5, ����� ����������
                    toDisable = currentBulletIndex - 5;
                    if (toDisable < 0) toDisable = 0;
                    {


                        if (currentBulletIndex == 0)
                        {
                            Rigidbody bulletDisable = bulletPoolTr.GetChild(bulletPoolTr.childCount - 5).GetComponent<Rigidbody>();
                            Rigidbody bulletRB = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                            bulletRB.gameObject.SetActive(true);
                            bulletDisable.gameObject.SetActive(false);
                            bulletRB.position = ShootingPoint.position;
                            bulletRB.velocity = Vector3.zero;
                            bulletRB.AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Impulse);
                            currentBulletIndex++;
                        }
                        else if (currentBulletIndex == 1)
                        {
                            Rigidbody bulletDisable = bulletPoolTr.GetChild(bulletPoolTr.childCount - 4).GetComponent<Rigidbody>();
                            Rigidbody bulletRB = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                            bulletRB.gameObject.SetActive(true);
                            bulletDisable.gameObject.SetActive(false);
                            bulletRB.position = ShootingPoint.position;
                            bulletRB.velocity = Vector3.zero;
                            bulletRB.AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Impulse);
                            currentBulletIndex++;
                        }
                        else if (currentBulletIndex == 2)
                        {
                            Rigidbody bulletDisable = bulletPoolTr.GetChild(bulletPoolTr.childCount - 3).GetComponent<Rigidbody>();
                            Rigidbody bulletRB = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                            bulletRB.gameObject.SetActive(true);
                            bulletDisable.gameObject.SetActive(false);
                            bulletRB.position = ShootingPoint.position;
                            bulletRB.velocity = Vector3.zero;
                            bulletRB.AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Impulse);
                            currentBulletIndex++;
                        }
                        else if (currentBulletIndex == 3)
                        {
                            Rigidbody bulletDisable = bulletPoolTr.GetChild(bulletPoolTr.childCount - 2).GetComponent<Rigidbody>();
                            Rigidbody bulletRB = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                            bulletRB.gameObject.SetActive(true);
                            bulletDisable.gameObject.SetActive(false);
                            bulletRB.position = ShootingPoint.position;
                            bulletRB.velocity = Vector3.zero;
                            bulletRB.AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Impulse);
                            currentBulletIndex++;
                        }
                        else if (currentBulletIndex == 4)
                        {
                            Rigidbody bulletDisable = bulletPoolTr.GetChild(bulletPoolTr.childCount - 1).GetComponent<Rigidbody>();
                            Rigidbody bulletRB = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                            bulletRB.gameObject.SetActive(true);
                            bulletDisable.gameObject.SetActive(false);
                            bulletRB.position = ShootingPoint.position;
                            bulletRB.velocity = Vector3.zero;
                            bulletRB.AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Impulse);
                            currentBulletIndex++;
                        }
                        else if (currentBulletIndex > 0)
                        {
                            Rigidbody bulletDisable = bulletPoolTr.GetChild(toDisable).GetComponent<Rigidbody>();
                            Rigidbody bulletRB = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
                            bulletRB.gameObject.SetActive(true);
                            bulletDisable.gameObject.SetActive(false);
                            bulletRB.position = ShootingPoint.position;
                            bulletRB.velocity = Vector3.zero;
                            bulletRB.AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Impulse);
                            currentBulletIndex++;
                        }
                        if (currentBulletIndex >= bulletPoolTr.childCount)
                        {
                            currentBulletIndex = 0;
                        }
                    }

                    #endregion

                }
            }
        }
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        GameObject temp = Instantiate(MyMine, MinePoint.position, Quaternion.identity);
                        Destroy(temp, 5f);
                    }
                }
            }
        


