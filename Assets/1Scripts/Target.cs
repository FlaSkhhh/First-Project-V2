using UnityEngine;  

public class Target : MonoBehaviour
{
    public float health = 30f;
    public void TakeDamage (float dmg)
    {
      health -= dmg;
      if (health <= 0f)
      {
        Die();
      }
    }
    public void Die()
    {
     Destroy(gameObject);
    }
}
