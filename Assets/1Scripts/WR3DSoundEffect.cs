using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WR3DSoundEffect : MonoBehaviour
{
    public AudioManager sound;
    public GameObject player;

    public void FallOff()
    {
        sound.Play("AnimeDeath");
        player.GetComponent<PlayerMovement>().enabled=false;
    }

}
