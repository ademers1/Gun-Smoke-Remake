using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Animate : MonoBehaviour
{
    public AIPath aiPath;
    Animator anim;
    public Transform parent;
    bool flipped;
    public int health = 1;
    public GameObject enemy;
    GameObject player;
    bool SpawnOnce = false;
    PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y - parent.transform.position.y >= 0.01)
        {
            anim.SetBool("ShootDown", false);
            anim.SetBool("ShootUp", true);
            anim.SetBool("RightOrLeft", false);
        }
        else if (player.transform.position.y - parent.transform.position.y <= 0.01f)
        {
            anim.SetBool("ShootUp", false);
            anim.SetBool("ShootDown", true);
            anim.SetBool("RightOrLeft", false);
        }
        if (aiPath.desiredVelocity.x >= 1f)
        {
            parent.transform.localScale = new Vector3(-1, 1, 1);
            aiPath.transform.localScale = new Vector3(-1, 1, 1);
            flipped = true;
            anim.SetBool("ShootUp", false);
            anim.SetBool("ShootDown", false);
            anim.SetBool("RightOrLeft", true);
        }
        if(aiPath.desiredVelocity.x <= -1f)
        {
            if (flipped)
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
                aiPath.transform.localScale = new Vector3(1, 1, 1);
                flipped = false;
            }
            anim.SetBool("ShootUp", false);
            anim.SetBool("ShootDown", false);
            anim.SetBool("RightOrLeft", true);
        }
        if (health <= 0) Killed();
    }

    public void Killed()
    {
        enemy.GetComponent<Enemy>().dead = true;
        Destroy(enemy.GetComponentInParent<Rigidbody2D>());
        aiPath.canMove = false;
        aiPath.transform.Translate(new Vector3(0, -1.5f * Time.deltaTime, 0));
        anim.SetBool("IsDead", true);
        if (!SpawnOnce)
        {
            SpawnOnce = true;
            enemy.GetComponent<Enemy>().SpawnDrop();
            Invoke("Remove", 0.2f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullets" && !collision.gameObject.GetComponent<Projectile>().enemyProjectile)
        {
            health--;
            if(playerScript.equippedGun != 3)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void Remove()
    {
        Destroy(enemy.transform.parent.gameObject);
        player.GetComponent<PlayerScript>().score += 100;
        player.GetComponent<PlayerScript>().UpdateScore();
    }
}
