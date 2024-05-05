using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireBallDamage : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    private float damage = 30f;
    public void OnTriggerEnter(Collider collider) 
    { 
    if (collider != null)
        {
            GameObject ex = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(ex, 2f);    

            if (collider.CompareTag("Player"))
            {
                PlayerHealth hp = collider.GetComponent<PlayerHealth>();
                if (collider.GetComponent<PlayerHealth>().enabled == true)
                {
                    Destroy(gameObject);
                    if (hp != null)
                    {
                        hp.TakeDamage(damage);
                    }
                }
            }
            if (collider.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
        }
    else
     {
     Destroy(gameObject,3f);
     }
    } 
}
