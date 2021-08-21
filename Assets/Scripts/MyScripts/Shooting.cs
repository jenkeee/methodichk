using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Tooltip("������ ����")]
    public GameObject Bullet;
    [Tooltip("� ������� ������ ������� ��������� ")]
    public Transform ShootingPoint; // ����� �������� ����

    public float bulletSpeed = 500;

    [Tooltip("���������� � ���������� ���������")]
    public Transform PlayerTransform;
    [Tooltip("���������� � ���������� ���������")]
    public Rigidbody PlayerRigidbody;

    private Transform cameraTransform;


    public Vector3 target { get; set; }
    public bool hit { get; set; }
    [SerializeField]
    private Transform bulletPoolTr;

    int currentBulletIndex = 0;

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody>(); // ���������� � ���������� ���������
        PlayerTransform = transform; // ���������� � ���������� ��������� ������� �� �������
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
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
    }

// Update is called once per frame
void Update()
    {

             if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            int toDisable = currentBulletIndex - 5;
            if (toDisable < 0) toDisable = 0;
            Rigidbody bulletDisable = bulletPoolTr.GetChild(toDisable).GetComponent<Rigidbody>();


            Rigidbody bulletRB = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();         
            bulletRB.gameObject.SetActive(true);
            bulletDisable.gameObject.SetActive(false);
            bulletRB.position = ShootingPoint.position;
            bulletRB.velocity = Vector3.zero;            
            bulletRB.AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Impulse);
            currentBulletIndex++;
            if (currentBulletIndex >= bulletPoolTr.childCount) {
                currentBulletIndex = 0;                
            }



            //DisappearanceLogic(bulletRB.gameObject);

            /*
             * Rigidbody bulletRB = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
            bulletRB.gameObject.SetActive(true);
            bulletRB.position = transform.position + Vector3.right;
            bulletRB.velocity = Vector3.zero;
            Vector3 pushDir = bulletRB.transform.position - Camera.main.transform.position;
            bulletRB.AddForce(pushDir.normalized * bulletSpeed, ForceMode.Impulse);
            currentBulletIndex++;
            if (currentBulletIndex >= bulletPoolTr.childCount) {
                currentBulletIndex = 0;
            }*/
            /* ��� � �������� � ������ ��� ����� ������
            GameObject temp = Instantiate(Bullet,ShootingPoint.position, Quaternion.identity); // ������� ���� 
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            Vector3 pushDir = temp.transform.position - Camera.main.transform.position;          
            tempRB.AddForce(pushDir.normalized * bulletSpeed, ForceMode.Impulse);
            Destroy(temp, 5f);*/
        }
    }   
}
