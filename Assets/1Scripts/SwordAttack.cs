using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public AudioManager sound;
    private float damage = 20f;
    public void OnTriggerExit(Collider collider)
    {
        if (collider != null)
        {
            if(collider.CompareTag("Boss"))
            {
                BossTarget hp = collider.GetComponent<BossTarget>();
                if (hp.enabled==true) 
                {
                    sound.Play("GunShotHit");
                    hp.TakeDamage(damage);
                }
            }
        }
    }
}
