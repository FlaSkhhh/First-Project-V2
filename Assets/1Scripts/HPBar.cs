using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public GameObject player;
    public Text hp;

    void Update()
    {
        if (player.GetComponent<PlayerHealth>().enabled == true)
        {
            PlayerHealth remhp = player.GetComponent<PlayerHealth>();
            var disphealth = remhp.health;
            hp.text = disphealth.ToString();
        }
    }
}
