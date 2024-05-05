using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject failedLevelUI;
    public GameObject Base;
    public GameObject V2;
    public GameObject Guns;
    public AudioManager sound;
    bool gameEnded = false;
    int index = 0;
    int reindex = 0;
    int gunindex = 0;
    string[] cheatCode;
    string[] recheatCode;
    string[] gunCheatCode;

    public void Start()
    {
        sound.Play("MainTheme");
        cheatCode = new string[] { "b", "o", "n", "k" };
        recheatCode = new string[] { "j", "e", "s", "u", "s" };
        gunCheatCode = new string[] { "a", "m", "e", "r", "i", "c", "a" };
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
            if (Input.GetKeyDown(recheatCode[reindex]))
            {
                reindex++;
            }
            
            else
            {
                reindex = 0;
            }
            if (Input.GetKeyDown(gunCheatCode[gunindex]))
            {
                gunindex++;
            }

            else
            {
                gunindex = 0;
            }
        }
        if (index == cheatCode.Length)
        {
            Base.SetActive(false);
            V2.SetActive(true);
            index = 0;
            V2.GetComponent<RollScript>().Vincible();
            V2.GetComponent<RollScript>().AttackEnd();
            Guns.SetActive(false);
        }
        if (reindex == recheatCode.Length)
        {
            Base.SetActive(true);
            V2.SetActive(false);
            reindex = 0;
            Base.GetComponent<RollScript>().Vincible();
            Base.GetComponent<RollScript>().AttackEnd();
            Guns.SetActive (false);
        }
        if(gunindex== gunCheatCode.Length)
        {
            Guns.SetActive(true);
            gunindex= 0;
        }
    }

    public void GameOver()
    {
        if (gameEnded == false) 
        {
            failedLevelUI.SetActive(true);
            sound.Play("DarkDied");
            Invoke("Restart", 6f);
            gameEnded = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Inputtry");  
    }

    public void Victory()
    {
        completeLevelUI.SetActive(true);
        Invoke("MainMenu", 2f);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}


