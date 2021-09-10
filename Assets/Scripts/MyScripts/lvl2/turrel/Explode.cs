using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float radius;
    public float force;

    static bool rdy_exp = false;
    public void Explosion()
    {

        Debug.Log("rdy_exp=true");
        Collider[] overlapedColls = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < overlapedColls.Length; i++)
        {
            Rigidbody RB = overlapedColls[i].attachedRigidbody;

            if (RB)
            {
                RB.AddExplosionForce(force, transform.position, radius);
            }
        }

    }

    public static void rdy_Explosion()
    {
        rdy_exp = true;
    }

    public static void Notrdy_Explosion()
    {
        rdy_exp = false;
    }

    private void Update()
    {
        if (rdy_exp)
        {
            Explosion();
        }
    }
}