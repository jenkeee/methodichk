using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Tooltip("префаб Мины")]
    public GameObject MyMine;
    [SerializeField]
    [Tooltip("Сюда пул пуль надо поместить")]
    private Transform bulletPoolTr;
    [Tooltip("в позиции какого объекта создается выстрел ")]
    public Transform ShootingPoint; // точка создания пули
    [Tooltip("в позиции какого объекта создается мина")]
    public Transform MinePoint; // точка создания мны

    public float bulletSpeed = 500;

    [Tooltip("обращаемся к компоненту трансформ")]
    public Transform PlayerTransform;
    [Tooltip("обращаемся к компоненту ригитбоди")]
    public Rigidbody PlayerRigidbody;

    private Transform cameraTransform;


    public Vector3 target { get; set; }
    public bool hit { get; set; }


    int currentBulletIndex = 0;
    int toDisable;

   


    bool m_playerHasPistol = false;
    [Tooltip("Сюда требуеться положить объект который исчезнет когда лемон его возмет")]
    public UnityEngine.Object m_PlasmaGun;
    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody>(); // обращаемся к компоненту ригитбоди
        PlayerTransform = transform; // обращаемся к компоненту трансформ который на объекте
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
        { m_playerHasPistol = true; }
    }
            // Update is called once per frame
            void Update()
    {
        if (m_playerHasPistol)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                #region пулинг пуль с очередью в 5, позже обработать
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

            if (Input.GetKeyDown(KeyCode.G))
            {
                GameObject temp = Instantiate(MyMine, MinePoint.position, Quaternion.identity); 
                Destroy(temp, 5f);
            }            
        }
    }
}
    

