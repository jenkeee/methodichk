using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrul : MonoBehaviour
{
    [SerializeField]
    float x;
    [SerializeField]
    float y = .1f;
    [SerializeField]
    float z;
    public  Transform player;
    Vector3 PlayerPos;
    [Tooltip("скорость с которой фоловим игрока")]
    public float speed;

    
    private static float t_lostPlayer;

    public static bool findEnemy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = player.transform.position;
        Vector3 direction = PlayerPos - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, speed * Time.deltaTime, 0);
        newDirection.y = 0;
        

        if (!findEnemy)
        {
            if (t_lostPlayer > y && t_lostPlayer > 3)
            {
                transform.Rotate(new Vector3(x, y + 3, z));
                t_lostPlayer -= Time.deltaTime;
            }
            else if (t_lostPlayer < 3 && t_lostPlayer > y)
            {
                transform.Rotate(new Vector3(x, y + t_lostPlayer, z));
                t_lostPlayer -= Time.deltaTime;
            }
            else if (t_lostPlayer < y)
            {
                transform.Rotate(new Vector3(x, y, z));
            }
        }
        else if (findEnemy)
        {

            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        
    }

    public static void FindEnemy()
    {
        findEnemy = true;       
    }
    public static void LostEnemy()
    {
        findEnemy = false;
        t_lostPlayer = 5;
    }
}
