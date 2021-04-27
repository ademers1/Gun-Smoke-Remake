using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile : MonoBehaviour
{  
    public float speed;

    public float xVelocity;

    public float yVelocity;

    public float lifetime = 0.1f;

    public float spawnTime;

    public Transform bullet;
    public Transform player;
    public PlayerScript playerScript;
    public SelectMenu selectMenu;

    public float xOffset;
    public float yOffset;

    public Vector3 playerPosition;

    public bool enemyProjectile = false;

    public int direction;

    public bool shotgun = false;
    public bool destSet = false;

    // Start is called before the first frame update
    void Start()
    {
        if (shotgun)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity * Time.deltaTime, yVelocity * Time.deltaTime);
        }
        else
        {
            if (direction == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity * Time.deltaTime, speed * Time.deltaTime);
            }
            if (direction == 1)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * Time.deltaTime);
            }
            if (direction == 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-xVelocity * Time.deltaTime, speed * Time.deltaTime);
            }
            // Destroy gameObject after 'lifeTime' seconds
        }

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        selectMenu = GameObject.FindGameObjectWithTag("Player").GetComponent<SelectMenu>();

        Destroy(gameObject, lifetime);

        
    }

    private void Update()
    {
        if (enemyProjectile && !destSet)
        {
            destSet = true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 dir = new Vector2(player.position.x - transform.position.x + xOffset, playerPosition.y - transform.position.y + yOffset);
            dir.Normalize();
            dir *= speed;
            rb.velocity = new Vector2(dir.x, dir.y);
            Destroy(gameObject, 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Barrel" && c.gameObject.GetComponent<BarrelScript>().health > 0)
        {
            Destroy(gameObject);
        }
        if (c.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
        }
        if(enemyProjectile && c.gameObject.tag == "Player")
        {
            if (playerScript.equippedGun == 4 && playerScript.smartbombAmmo > 0)
            {
                Destroy(gameObject);
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject o in enemies)
                {
                    o.GetComponentInChildren<Animate>().health = 0;
                }
                selectMenu.UpdateSelectScreenText(playerScript.equippedGun);
                playerScript.equippedGun = 0;
                playerScript.smartBombOwned = false;
                playerScript.smartbombAmmo = 0;
            }
            else
            {
                playerScript.health--;
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullets");
                foreach(GameObject o in bullets)
                {
                    Destroy(o);
                }
            }
        }
    }

}
