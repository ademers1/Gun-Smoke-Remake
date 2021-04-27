using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{

    public GameObject menu;
    public GameObject boot1;
    public GameObject boot2;
    public GameObject boot3;
    public GameObject boot4;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject shotgunText;
    public GameObject machinegunText;
    public GameObject magnumText;
    public GameObject smartbombText;
    public GameObject shotgunAmmo;
    public GameObject machinegunAmmo;
    public GameObject magnumAmmo;
    public GameObject smartbombAmmo;
    public GameObject gunSelector;
    bool gunChangeActive = false;

    public GameObject player;
    PlayerScript ps;
    bool menuActive = false;



    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        if (player)
        {
            ps = player.GetComponent<PlayerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuActive && Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0)
        {
            gunChangeActive = true;
            Time.timeScale = 0;
            menu.SetActive(true);
            StartCoroutine("ChangeMenuState");
        }
        
        if(menuActive && Input.GetKeyDown(KeyCode.Space))
        {
            gunChangeActive = false;
            Time.timeScale = 1;
            menu.SetActive(false);
            StartCoroutine("ChangeMenuState");
        }

        if (menuActive && Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }

        UpdateBootSprites();
        UpdateGunSprites();
        UpdateLivesSprites();
        UpdateShotgunText();
        UpdateMachinegunText();
        UpdateMagnumText();
        UpdateSmartbombText();
        if (gunChangeActive)
        {
            UpdateChangeSelectedGun();
        }
    }

    private void UpdateChangeSelectedGun()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && ps.equippedGun == 0)
        {
            GunChangeNormal();          
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && ps.equippedGun == 0)
        {
            GunChangeNormalDown();
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && ps.equippedGun == 1)
        {
            GunChangeShotgun();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && ps.equippedGun == 1)
        {
            GunChangeShotgunDown();
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && ps.equippedGun == 2)
        {
            GunChangeMachinegun();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && ps.equippedGun == 2)
        {
            GunChangeMachinegunDown();
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && ps.equippedGun == 3)
        {
            GunChangeMagnum();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && ps.equippedGun == 3)
        {
            GunChangeMagnumDown();
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && ps.equippedGun == 4)
        {
            GunChangeSmartbomb();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && ps.equippedGun == 4)
        {
            GunChangeSmartbombDown();
        }
    }

    IEnumerator ChangeMenuState()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        menuActive = !menuActive;
    }

    private void UpdateShotgunText()
    {
        if (ps.shotgunOwned)
        {
            shotgunText.SetActive(true);
            shotgunAmmo.GetComponent<Text>().text = ps.shotgunAmmo.ToString();
            shotgunAmmo.SetActive(true);
        }
    }

    private void UpdateMachinegunText()
    {
        if (ps.machinegunOwned)
        {
            machinegunText.SetActive(true);
            machinegunAmmo.GetComponent<Text>().text = ps.machineGunAmmo.ToString();
            machinegunAmmo.SetActive(true);
        }
    }

    private void UpdateMagnumText()
    {
        if (ps.magnumOwned)
        {
            magnumText.SetActive(true);
            magnumAmmo.GetComponent<Text>().text = ps.magnumAmmo.ToString();
            magnumAmmo.SetActive(true);
        }
    }

    private void UpdateSmartbombText()
    {
        if (ps.smartBombOwned)
        {
            smartbombText.SetActive(true);
            smartbombAmmo.GetComponent<Text>().text = ps.smartbombAmmo.ToString();
            smartbombAmmo.SetActive(true);
        }
    }

    public void UpdateSelectScreenText(int gunToRemove)
    {
        Vector3 tmp = gunSelector.transform.position;
        tmp.y = -.66f;
        gunSelector.transform.position = tmp;
        switch (gunToRemove)
        {
            case 1: shotgunText.SetActive(false);
                shotgunAmmo.SetActive(false);
                break;
            case 2: machinegunText.SetActive(false);
                machinegunText.SetActive(false);
                break;
            case 3: magnumText.SetActive(false);
                magnumAmmo.SetActive(false);
                break;
            case 4: smartbombText.SetActive(false);
                smartbombAmmo.SetActive(false);
                break;
            default: break;                
        }
    }

    void UpdateBootSprites()
    {
        if(ps.boots == 0)
        {
            boot1.SetActive(false);
            boot2.SetActive(false);
            boot3.SetActive(false);
            boot4.SetActive(false);
        }
        if(ps.boots == 1)
        {
            boot1.SetActive(true);
            boot2.SetActive(false);
            boot3.SetActive(false);
            boot4.SetActive(false);
        }
        if(ps.boots == 2)
        {
            boot1.SetActive(true);
            boot2.SetActive(true);
            boot3.SetActive(false);
            boot4.SetActive(false);
        }
        if(ps.boots == 3)
        {
            boot1.SetActive(true);
            boot2.SetActive(true);
            boot3.SetActive(true);
            boot4.SetActive(false);
        }
        if (ps.boots == 4)
        {
            boot1.SetActive(true);
            boot2.SetActive(true);
            boot3.SetActive(true);
            boot4.SetActive(true);
        }
    }

    void UpdateGunSprites()
    {
        if (ps.fireRange == 0)
        {
            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(false);
        }
        if (ps.fireRange == 1)
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(false);
        }
        if (ps.fireRange == 2)
        {
            gun1.SetActive(true);
            gun2.SetActive(true);
            gun3.SetActive(false);
            gun4.SetActive(false);
        }
        if (ps.fireRange == 3)
        {
            gun1.SetActive(true);
            gun2.SetActive(true);
            gun3.SetActive(true);
            gun4.SetActive(false);
        }
        if (ps.fireRange == 4)
        {
            gun1.SetActive(true);
            gun2.SetActive(true);
            gun3.SetActive(true);
            gun4.SetActive(true);
        }
    }

    void UpdateLivesSprites()
    {
        if(ps.lives == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }
        if(ps.lives == 2)
        {
            life1.SetActive(true);
            life2.SetActive(false);
            life3.SetActive(false);
        }
        if(ps.lives == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(false);
        }
        if(ps.lives == 4)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
    }

    private void GunChangeNormal()
    {
        if (ps.smartBombOwned && ps.smartbombAmmo > 0)
        {
            ps.equippedGun = 4;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.1f;
            gunSelector.transform.position = tmp;
        }
        else if (ps.magnumOwned && ps.magnumAmmo > 0)
        {
            ps.equippedGun = 3;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.82f;
            gunSelector.transform.position = tmp;
        }
        else if (ps.machinegunOwned && ps.machineGunAmmo > 0)
        {
            ps.equippedGun = 2;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 1.54f;
            gunSelector.transform.position = tmp;
        }
        else if (ps.shotgunOwned && ps.shotgunAmmo > 0)
        {
            ps.equippedGun = 1;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 2.36f;
            gunSelector.transform.position = tmp;
        }
    }

    private void GunChangeNormalDown()
    {
        if (ps.shotgunOwned && ps.shotgunAmmo > 0)
        {
            ps.equippedGun = 1;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 2.36f;
            gunSelector.transform.position = tmp;
        }

        else if (ps.machinegunOwned && ps.machineGunAmmo > 0)
        {
            ps.equippedGun = 2;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 1.54f;
            gunSelector.transform.position = tmp;
        }

        else if (ps.magnumOwned &&  ps.magnumAmmo > 0)
        {
            ps.equippedGun = 3;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.82f;
            gunSelector.transform.position = tmp;
        }

        else if (ps.smartBombOwned && ps.smartbombAmmo > 0)
        {
            ps.equippedGun = 4;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.1f;
            gunSelector.transform.position = tmp;
        }
    }

    private void GunChangeShotgun()
    {
        ps.equippedGun = 0;
        Vector3 tmp = gunSelector.transform.position;
        tmp.y = -.66f;
        gunSelector.transform.position = tmp;
    }

    private void GunChangeShotgunDown()
    {
        if (ps.machinegunOwned && ps.machineGunAmmo > 0)
        {
            ps.equippedGun = 2;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 1.54f;
            gunSelector.transform.position = tmp;
        }
        else if (ps.magnumOwned && ps.magnumAmmo > 0)
        {
            ps.equippedGun = 3;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.82f;
            gunSelector.transform.position = tmp;
        }

        else if (ps.smartBombOwned && ps.smartbombAmmo > 0)
        {
            ps.equippedGun = 4;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.1f;
            gunSelector.transform.position = tmp;
        }
        else
        {
            ps.equippedGun = 0;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = -.66f;
            gunSelector.transform.position = tmp;
        }
    }

    private void GunChangeMachinegun()
    {
        if (ps.shotgunOwned && ps.shotgunAmmo > 0)
        {
            ps.equippedGun = 1;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 2.36f;
            gunSelector.transform.position = tmp;
        }
        else
        {
            ps.equippedGun = 0;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = -.66f;
            gunSelector.transform.position = tmp;
        }
    }

    private void GunChangeMachinegunDown()
    {
        if (ps.magnumOwned && ps.magnumAmmo > 0)
        {
            ps.equippedGun = 3;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.82f;
            gunSelector.transform.position = tmp;
        }

        else if (ps.smartBombOwned && ps.smartbombAmmo > 0)
        {
            ps.equippedGun = 4;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.1f;
            gunSelector.transform.position = tmp;
        }
        else
        {
            ps.equippedGun = 0;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = -.66f;
            gunSelector.transform.position = tmp;
        }
    }

    private void GunChangeMagnum()
    {
        if (ps.machinegunOwned && ps.machineGunAmmo > 0)
        {
            ps.equippedGun = 2;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 1.54f;
            gunSelector.transform.position = tmp;
        }
        else if (ps.shotgunOwned && ps.shotgunAmmo > 0)
        {
            ps.equippedGun = 1;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 2.36f;
            gunSelector.transform.position = tmp;
        }
        else
        {
            ps.equippedGun = 0;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = -.66f;
            gunSelector.transform.position = tmp;
        }
    }

    private void GunChangeMagnumDown()
    {
        if (ps.smartBombOwned && ps.smartbombAmmo > 0)
        {
            ps.equippedGun = 4;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.1f;
            gunSelector.transform.position = tmp;
        }
        else
        {
            ps.equippedGun = 0;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = -.66f;
            gunSelector.transform.position = tmp;
        }
    }

    private void GunChangeSmartbomb()
    {
        if (ps.magnumOwned && ps.magnumAmmo > 0)
        {
            ps.equippedGun = 3;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 0.82f;
            gunSelector.transform.position = tmp;
        }
        else if (ps.machinegunOwned && ps.magnumAmmo > 0)
        {
            ps.equippedGun = 2;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 1.54f;
            gunSelector.transform.position = tmp;
        }
        else if (ps.shotgunOwned && ps.shotgunAmmo > 0)
        {
            ps.equippedGun = 1;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = 2.36f;
            gunSelector.transform.position = tmp;
        }
        else
        {
            ps.equippedGun = 0;
            Vector3 tmp = gunSelector.transform.position;
            tmp.y = -.66f;
            gunSelector.transform.position = tmp;
        }
    }
    private void GunChangeSmartbombDown()
    {
        ps.equippedGun = 0;
        Vector3 tmp = gunSelector.transform.position;
        tmp.y = -.66f;
        gunSelector.transform.position = tmp;
    }
}
