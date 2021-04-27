using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpingHand : MonoBehaviour
{
    public GameObject ladyShop;
    public GameObject arrow;
    public GameObject storeMusic;
    public GameObject levelMusic;
    int weapon = 1;
    bool storeMusicPlayed = false;
    bool gameMusicPaused = false;
    public GameObject player;
    public PlayerScript playerScript;
    const int _ShotGunPrice = 6000;
    const int _SmartBombPrice = 8000;
    const int _MachineGunPrice = 10000;
    const int _MagnumPrice = 20000;

    void Start()
    {
        ladyShop.SetActive(false);
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (weapon > 1)
                    weapon--;
                else
                {
                    weapon = 4;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (weapon < 4)
                    weapon++;
                else
                {
                    weapon = 1;
                }
            }
            ChangeStoreOption();
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if(weapon == 1 && playerScript.score >= _ShotGunPrice && !playerScript.shotgunOwned)
                {
                    playerScript.score -= _ShotGunPrice;
                    playerScript.UpdateScore();
                    playerScript.shotgunOwned = true;
                }
                if (weapon == 2 && playerScript.score >= _SmartBombPrice && !playerScript.smartBombOwned)
                {
                    playerScript.score -= _SmartBombPrice;
                    playerScript.UpdateScore();
                    playerScript.smartBombOwned = true;
                }
                if (weapon == 3 && playerScript.score >= _MachineGunPrice && !playerScript.machinegunOwned)
                {
                    playerScript.score -= _MachineGunPrice;
                    playerScript.UpdateScore();
                    playerScript.machinegunOwned = true;
                }
                if (weapon == 4 && playerScript.score >= _MagnumPrice && !playerScript.magnumOwned)
                {
                    playerScript.score -= _MagnumPrice;
                    playerScript.UpdateScore();
                    playerScript.magnumOwned = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && ladyShop.activeSelf)
        {
            Time.timeScale = 1;
            ladyShop.SetActive(false);
            storeMusic.GetComponent<AudioSource>().mute = true;
            levelMusic.GetComponent<AudioSource>().Stop();
            levelMusic.GetComponent<AudioSource>().mute = false;
            levelMusic.GetComponent<AudioSource>().Play();
            weapon = 1;
        }
        else
        {
            if (!storeMusicPlayed)
            {
                levelMusic.GetComponent<AudioSource>().mute = false;
                storeMusic.GetComponent<AudioSource>().mute = true;
            }                             
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ladyShop.SetActive(true);
            weapon = 1;
            
            levelMusic.GetComponent<AudioSource>().mute = true;
            storeMusic.GetComponent<AudioSource>().mute = false;            
            Time.timeScale = 0;
            storeMusicPlayed = true;
        }
    }

    void ChangeStoreOption()
    {
        if(weapon == 1)
        {
            Vector3 tmp = arrow.transform.position;
            tmp.y = 0.41f;
            arrow.transform.position = tmp;
        }
        else if (weapon == 2)
        {
            Vector3 tmp = arrow.transform.position;
            tmp.y = -0.25f;
            arrow.transform.position = tmp;
        }
        else if(weapon == 3)
        {
            Vector3 tmp = arrow.transform.position;
            tmp.y = -0.92f;
            arrow.transform.position = tmp;
        }
        else if (weapon == 4)
        {
            Vector3 tmp = arrow.transform.position;
            tmp.y = -1.59f;
            arrow.transform.position = tmp;
        }
        else
        {
            weapon = 1;
            Vector3 tmp = arrow.transform.position;
            tmp.y = 0.05f;
            arrow.transform.position = tmp;
        }
    }
}
