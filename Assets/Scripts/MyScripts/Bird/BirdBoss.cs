using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdBoss : MonoBehaviour
{
    
    /// //////////////////////////////// для счетчика
        public GameObject ScoreText;
   public int Score;
    public GameEnding gameEnding;
    public AudioSource exitAudio;
    public CanvasGroup exitBackgroundImageCanvasGroup;

    [SerializeField] private int _health;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
