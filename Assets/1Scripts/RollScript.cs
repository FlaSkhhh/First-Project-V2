using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollScript : MonoBehaviour
{
    public GameObject sword;
    public Camera cam;
    private Vector3 offset;
    public CharacterController controller;
    public GameObject player;

    public void Invincible()
    {
        player.GetComponent<PlayerHealth>().enabled = false;
        //offset = new Vector3(cam.transform.position.x,cam.transform.position.y-0.7f,cam.transform.position.z);
        //cam.transform.position = offset;
        //Vector3 move = cam.transform.right;
        //controller.Move(move * 2f);
    }

    public void Vincible()
    {
        player.GetComponent<PlayerHealth>().enabled = true;
        //offset = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.7f, cam.transform.position.z);
        //cam.transform.position = offset;
        GetComponentInParent<PlayerMovement>().isRolling = false;
        GetComponentInParent<PlayerMovement>().leftRoll = false;
        GetComponentInParent<PlayerMovement>().rightRoll = false;
        GetComponentInParent<PlayerMovement>().forwardRoll = false;
        GetComponentInParent<PlayerMovement>().backwardRoll = false;
    }

    public void Jump()
    {
        Vector3 Velocity = new Vector3(0, 4f, 0);
        controller.Move(Velocity * Time.deltaTime);
    }

    public void AttackStart()
    {
        sword.GetComponent<Collider>().enabled = true;
    }

    public void AttackEnd()
    {
        sword.GetComponent<Collider>().enabled = false;
    }
}
