using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyEnemy : MonoBehaviour
{
    
    /// //////////////////////////////// для счетчика
        public GameObject ScoreText;
   public int Score;
    public GameEnding gameEnding;
    public AudioSource exitAudio;
    public CanvasGroup exitBackgroundImageCanvasGroup;
   static GameObject MyObg;
    [SerializeField] private int _health;
    static int HP = 100;
    /* public void Count()
     {
         Score++;        
         ScoreText.GetComponent<Text>().text = "закидано какахами: " + Score.ToString() + "/ 4.";
         if (Score >=4)
         gameEnding.EndLevel(exitBackgroundImageCanvasGroup, false , exitAudio);
     }*/

    public void Hurt(int damage)
        {
            print("Ouch: " +damage);

            _health -= damage; ;

            if (_health <= 0)
            {            
                            Die();
            }
        }
    public static void Hurt2(int damage)
    {
        print("Ouch2: " + damage);

        
        HP-= damage; 

        if (HP <= 0)
        {
            print("Ouch: помер " );
            MyObg.SetActive(false);
        }
    }

    private void Die()
        {
        gameEnding.Count();
        gameObject.SetActive(false);        
                  // Destroy(gameObject);
    }

    private void OnCollisionEnter (Collision other)
    {
       /* if (other.collider.tag == "Bullet") {
            Vector3 vel = other.collider.GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().AddForce(vel * 500, ForceMode.Impulse);
           // other.collider.gameObject.SetActive(false); // позже обработаю
        }*/
    }
    // Start is called before the first frame update
    void Awake()
    {
        Score = 0;
        MyObg = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
