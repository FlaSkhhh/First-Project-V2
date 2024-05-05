using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public Animator animatorBase;
    public Animator animatorV2;
    public AudioManager sound;
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health > 0f)
        {
            sound.Play("PlayerHurt");
        }
    }
    
    //void OnTriggerEnter(Collider c)
    //{ 
    //    if (invincible==false)
    //    {
    //        if (c.CompareTag("Mouth"))
    //        {
    //            TakeDamage(20);
    //        }
    //        if (c.CompareTag("HeadCrab"))
    //        {
    //            TakeDamage(10);
    //        }
    //    }
    //}
    void Update()
    {
      if (health <= 0f)
      {
         Invoke("Die", 0f);
         health = 0f;
      }

      Transform pos = GetComponent<Transform>();
      if (pos.position.y < 4f) 
      {
         TakeDamage(100);
         health = 0f    ;
         Invoke("Die", 2f);
      }
    }

    public void Die()
    {
        animatorBase.SetTrigger("Death");
        animatorV2.SetTrigger("Death");
        Invoke("GameOver", 2.9f);
    }

    public void GameOver()
    {
        FindObjectOfType<GameManager>().GameOver();
    }
}

