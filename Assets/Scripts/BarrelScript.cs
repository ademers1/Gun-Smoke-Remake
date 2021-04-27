using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public int itemId;

    public Sprite destroyedBarrel;

    public Sprite rifle;

    public Sprite boots;

    public Sprite ammo;

    public Sprite money;

    public Sprite pow;

    public Sprite poster;

    GameObject player;
    PlayerScript playerScript;

    public int health = 6;
    
    enum item {Rifle = 0, Boots = 1, Money = 2, Ammo = 3, Poster = 4, Pow = 5, ExtraLife = 6, Invincibilty = 7}
    // Start is called before the first frame update
    void Start()
    {
        if (itemId == 0)
        {
            Debug.Log("Item Id not set in Inspector. Defaulting to Money.");
            itemId = 2;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            health = -1;
            player.GetComponent<PlayerScript>().score += 50;
            player.GetComponent<PlayerScript>().UpdateScore();
            this.GetComponent<SpriteRenderer>().sprite = destroyedBarrel;
            this.transform.localScale = new Vector3(2.4f, 2.4f, 2.4f);
            Invoke("ChangeToItem", 0.3f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullets" && health > 0)
        {
            if(playerScript.equippedGun == 3)
            {
                health -= 2;
            }
            health--;
        }
        if(collision.gameObject.tag == "Player" && health < 0)
        {
            switch (itemId)
            {
                case 1: if(playerScript.fireRange < 3) playerScript.fireRange += 1;
                    break;
                case 2: if (playerScript.boots < 3) playerScript.boots += 1;
                    break;
                case 3:  UpdateAmmo();
                    break;
                case 4:  playerScript.score += 100;
                    playerScript.UpdateScore();
                    break;
                case 5: GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach(GameObject o in enemies)
                    {
                        o.GetComponentInChildren<Animate>().health = 0;
                    }
                    break;
                case 6:  playerScript.posterCollected = true;
                    break;
                default: break;
            }
            Destroy(this.gameObject);
        }
    }
    void ChangeToItem()
    {
        if(itemId == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = rifle;
            this.transform.localScale = new Vector3(6, 6, 6);            
        }
        if(itemId == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = boots;
            this.transform.localScale = new Vector3(6, 6, 6);
        }
        if (itemId == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = ammo;
            this.transform.localScale = new Vector3(6, 6, 6);
            if (!playerScript.gunOwned) {
                Destroy(this.gameObject);
            }
        }
        if (itemId == 4)
        {
            this.GetComponent<SpriteRenderer>().sprite = money;
            this.transform.localScale = new Vector3(6, 6, 6);
        }
        if (itemId == 5)
        {
            this.GetComponent<SpriteRenderer>().sprite = pow;
            this.transform.localScale = new Vector3(6, 6, 6);
        }
        if(itemId == 6)
        {
            this.GetComponent<SpriteRenderer>().sprite = poster;
            this.transform.localScale = new Vector3(6, 6, 6);
        }
    }

    void UpdateAmmo()
    {        
        if(playerScript.machinegunOwned && playerScript.machineGunAmmo < 400)
        {
            playerScript.machineGunAmmo += 40;
            if(playerScript.machineGunAmmo > 400)
            {
                playerScript.machineGunAmmo = 400;
            }
        }
        if(playerScript.smartBombOwned && playerScript.smartbombAmmo < 1)
        {
            playerScript.smartbombAmmo = 1;
        }
        if(playerScript.magnumOwned && playerScript.magnumAmmo < 120)
        {
            playerScript.magnumAmmo += 20;
            if(playerScript.magnumAmmo > 120)
            {
                playerScript.magnumAmmo = 120;
            }
        }
        if(playerScript.shotgunOwned && playerScript.shotgunAmmo < 120)
        {
            playerScript.shotgunAmmo += 20;
            if(playerScript.shotgunAmmo > 120)
            {
                playerScript.shotgunAmmo = 120;
            }
        }
    }
}
