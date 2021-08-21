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
    private Transform bulletParent;
    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody>(); // ���������� � ���������� ���������
        PlayerTransform = transform; // ���������� � ���������� ��������� ������� �� �������
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     
        if (Input.GetKeyDown(KeyCode.Mouse0)) {

           
            GameObject temp = Instantiate(Bullet,ShootingPoint.position, Quaternion.identity); // ������� ���� 
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            Vector3 pushDir = temp.transform.position - Camera.main.transform.position;          
            tempRB.AddForce(pushDir.normalized * bulletSpeed, ForceMode.Impulse);
            Destroy(temp, 5f);
        }
    }   
}
