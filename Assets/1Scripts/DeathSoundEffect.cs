using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSoundEffect : MonoBehaviour
{
    public AudioManager sound;
    public GameObject player;

    public void FallOff()
    {
        sound.Play("AnimeV2Death");
        player.GetComponent<PlayerMovement>().enabled = false;

    }
}
