using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteAttack : MonoBehaviour
{
   public GameObject player;
   void OnTriggerEnter(Collider c)
   {
        if (c.CompareTag("Player"))
        {
            if (player.GetComponent<PlayerHealth>().enabled)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(20);
            } 
        }
        
   }
}
