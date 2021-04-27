using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool bullets;
    PlayerScript Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.tag == "Player")
        {
            if (!bullets)
            {
                Player.score += 100;
                Player.UpdateScore();
                Destroy(this.gameObject);
            }
            else
            {
                if (Player.shotgunOwned)
                {
                    Player.shotgunAmmo += 20;
                }
                if (Player.smartBombOwned)
                {
                    Player.smartbombAmmo = 1;
                }
                if (Player.machinegunOwned)
                {
                    Player.machineGunAmmo += 40;
                }
                if (Player.magnumOwned)
                {
                    Player.magnumAmmo += 20;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
