using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_shooting : MonoBehaviour
{
    [SerializeField] // хоть и приват но можем мен€ть
    [Tooltip("—юда пул пуль надо поместить")]
    private Transform bulletPoolTr;
    [Tooltip("в позиции какого объекта создаетс€ выстрел ")]
    public Transform ShootingPoint; // точка создани€ пули
    int currentBulletIndex = 0;

    public int t_fire;
    static int auto_fire;
    static bool readyTofire = true;
    static bool findEnemy;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         auto_fire -= 1;


        if (findEnemy)
        {
            readyTofire = false;
            auto_fire = 200;
            //bulletPoolTr.GetChild(currentBulletIndex).transform.gameObject.SetActive(true);
            Rigidbody Bullet = bulletPoolTr.GetChild(currentBulletIndex).GetComponent<Rigidbody>();
            Bullet.gameObject.SetActive(true);
            Bullet.position = ShootingPoint.position;
            Bullet.velocity = Vector3.zero;
            Vector3 grenade = new Vector3(0, 2, 0);
            Bullet.AddForce(gameObject.transform.forward * 10 + grenade, ForceMode.Impulse);
           // Debug.Log("турель щелкнула");
            currentBulletIndex++;
            findEnemy = false;
        }
        else if (auto_fire <= 0)
        {
            readyTofire = true;
            auto_fire = 200;
        }
        if (currentBulletIndex >= bulletPoolTr.childCount)
        {
            currentBulletIndex = 0;
        }


    }

    public static void FindEnemy()
    {
        if (readyTofire)
        {
            findEnemy = true;           
        }
    }
    public static void LostEnemy()
    {
        findEnemy = false;        
    }
}
