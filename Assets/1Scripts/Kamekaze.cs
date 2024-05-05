using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamekaze : MonoBehaviour
{
    private Transform target;
    private bool isBlowing = false;
    public GameObject headcrab;
    public GameObject explosion;
    public float explodingDist;
    void Start()
    {
      target = PlayerManager.instance.player.transform;
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < explodingDist && isBlowing == false)
        {
            isBlowing = true;
            GameObject sui = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(sui, 1f);
            Destroy(headcrab, 1f);
        }
        else
        {
            isBlowing = false;
        }
    }
}
