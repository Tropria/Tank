using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    public int damage = 5;
    public float explosionForce;
    public float explosionRadius;
    public GameObject explosionEffect;
    public float explosionTimeUp;

    private LayerMask enemyLayer;

    public void Init(LayerMask enemylm)
    {
        enemyLayer = enemylm;
    }

    private void OnCollisionEnter()
    {
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(obj, explosionTimeUp);

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        Debug.Log(cols.Length);

        if(cols.Length > 0)
        {
            for(int i=0; i<cols.Length; i++)
            {
                Rigidbody r = cols[i].GetComponent<Rigidbody>();
                if(r != null)
                {
                    r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }

                Unit u = cols[i].GetComponent<Unit>();
                if(u != null)//if this unit is a tankEnemy
                {
                    u.ApplyDamage(damage);
                }
            }
        }
    }
}
