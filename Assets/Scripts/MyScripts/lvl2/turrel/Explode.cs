using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float radius;
    public float force;

    static bool rdy_exp = false;

    [SerializeField] GameObject WHTA;
    static GameObject thisBoom;

    public GameObject ExplosionEffect;

    public void Explosion()
    {
        //Debug.Log("rdy_exp=true");
        Collider[] overlapedColls = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < overlapedColls.Length; i++)
        {
            Rigidbody RB = overlapedColls[i].attachedRigidbody;

            if (RB)
            {
                RB.AddExplosionForce(force, transform.position, radius);
                t_grd.ReadyTo();
                ExplosiveBarrel explosion = RB.GetComponent<ExplosiveBarrel>();
                if (explosion)
                {
                    explosion.takeDmg(100);
                }    

            }
            Notrdy_Explosion();
        }
    }

    public static void rdy_Explosion()
    {
        rdy_exp = true;
    }
    private void Awake()
    {
        thisBoom = WHTA;
    }
    public static void Notrdy_Explosion()
    {       
        rdy_exp = false;
        Rigidbody ramble = thisBoom.GetComponent<Rigidbody>();
        ramble.velocity = Vector3.zero;
    }

    private void Update()
    {
        if (rdy_exp)
        {
            Explosion();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
}