using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
         [SerializeField] private int _health;

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
        gameObject.SetActive(false);
          // Destroy(gameObject);
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.collider.tag == "Bullet") {
            Vector3 vel = other.collider.GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().AddForce(vel * 500, ForceMode.Impulse);
           // other.collider.gameObject.SetActive(false); // позже обработаю
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
