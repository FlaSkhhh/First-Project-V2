using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    public float lookRadius = 25f;
    Transform target;
    public Animator animator;
    private float nextFire = 0f;
    private float fireRate = 2f;
    public GameObject spawn;
    public GameObject FireBall;
    public AudioManager sound;
    public GameManager gm;
    public GameObject Mouth;
    private Transform hitbox;
    private bool isFlying = false;
    public Vector3 shootAt;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        hitbox = transform.Find("DragonSoulEater");
    }

    void Update()
    {if (isFlying == false)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            //Debug.Log(distance);
            if (distance <= lookRadius)
            {
                animator.SetFloat("Speed", 2);
                agent.SetDestination(target.position);
                if (distance <= 13f && distance >= 9f)
                {
                    agent.speed = 0f;
                    animator.SetFloat("Speed", 0);
                    FaceTarget();
                    if (Time.time >= nextFire)
                    {
                        nextFire = Time.time + 1 / fireRate;
                        animator.SetTrigger("FireBall");
                    }
                }
                else if (distance <= 3f)
                {
                    agent.speed = 0f;
                    animator.SetFloat("Speed", 0);
                    FaceTarget();
                    animator.ResetTrigger("FireBall");
                    if (Time.time >= nextFire)
                    {
                        agent.speed = 0f;
                        nextFire = Time.time + 1 / fireRate;
                        animator.SetTrigger("Bite");
                    }
                }
                else
                {
                    agent.speed = 3.5f;
                    animator.SetFloat("Speed", 2);
                    agent.SetDestination(target.position);
                }
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Attack()
    {
        sound.Play("FireBall");
        GameObject FBall = Instantiate(FireBall, spawn.transform.position, spawn.transform.rotation);
        Rigidbody rb = FBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce((Vector3.forward * 17f + Vector3.up * 4f), ForceMode.Impulse);
    }

    public void Bite()
    {
        Mouth.GetComponent<Collider>().enabled = true;;
        transform.position = transform.position + transform.forward*0.3f;
        sound.Play("Chomp");
    }

    public void BiteClosed()
    {
        Mouth.GetComponent<Collider>().enabled = false;
    }

    public void Victory()
    {
        gm.Victory();
    }

    public void Invulnerable()
    {
        hitbox.GetComponent<BossTarget>().enabled = false;
        agent.speed = 0f;
        isFlying = true;
    }

    public void Flying()
    {
        hitbox.GetComponent<CapsuleCollider>().enabled = false;
        agent.speed = 1f;
    }

    public void Vulnerable()
    {
        hitbox.GetComponent<CapsuleCollider>().enabled = true;
        hitbox.GetComponent<BossTarget>().enabled = true;
        agent.speed = 3.5f;
        isFlying = false;
    }

    public void AirAttack()
    {
        shootAt = (spawn.transform.position - target.position).normalized;
        agent.SetDestination(target.position);

    }

    public void AirShot()
    {
        sound.Play("FireBall");
        GameObject FBall = Instantiate(FireBall, spawn.transform.position, Quaternion.LookRotation(-shootAt));
        Rigidbody rb = FBall.GetComponent<Rigidbody>();
        rb.velocity = (-shootAt * 25f) + (rb.transform.up * 3f);
    }
}
