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

    private IEnumerator MyFirstCorutines(int cont)
    {
        
        while (true)
        { yield return new WaitForSeconds(Random.Range(1, 3)); }
            }

    public void takeDmg(int damage)
    {
        print("бочка: " + damage);

        HP -= damage;

        if (HP <= 0)
        {
            MyFirstCorutines(12);
            Die();
            print("бочка: взрыв ");
            Explode barrelToExp = RB.GetComponent<Explode>();
            if (barrelToExp)
            {
                barrelToExp.Explosion();
            }
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
