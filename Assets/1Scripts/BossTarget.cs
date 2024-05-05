using UnityEngine;

public class BossTarget : MonoBehaviour
{
    public float fullHealth = 200f;
    public float health;
    public Animator animator;
    private bool phaseChange = false;
    public BossHealthBar hpbar;

    void Start()
    {
        hpbar.SetFullHealth(fullHealth);
        health = fullHealth;
    }

    public void TakeDamage(float dmg)
    {
        animator.SetTrigger("GotHit");
        health -= dmg;
        hpbar.SetHealth(health);
        if (health < 101f && phaseChange ==false)
        {
            phaseChange = true;
            animator.SetTrigger("Phase2");
        }
        else if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("Death", true);
    }
}
