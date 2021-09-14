using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    static int HP = 100;

    public float radius;
    public float force;
    Rigidbody RB;

    private void Die()
    {
        RB.AddExplosionForce(force, transform.position, radius);
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }

    public void takeDmg(int damage)
    {
        print("бочка: " + damage);

        HP -= damage;

        if (HP <= 0)
        {
            Die();
            print("бочка: взрыв ");
        }
    }
   
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
