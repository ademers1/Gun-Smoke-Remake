using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Projectile enemyProjectile;

    public float maximumLookDistance = 30.0f;
    public float maximumAttackDistance = 25.0f;
    public float minimumDistanceFromPlayer = 2.0f;

    public float shotInterval;

    private float shotTime = 0;

    public bool dead = false;

    PlayerScript playerScript;

    public GameObject moneyPrefab;
    public GameObject bulletPrefab;

    bool above;
    bool below;
    int moveSideways;
    float speed = 5.0f;
    System.Random random;
    new SpriteRenderer renderer;

    private void Awake()
    {
        random = new System.Random();
        renderer = GetComponent<SpriteRenderer>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= maximumLookDistance)
        {
            LookAtTarget();
            if (!dead)
            {
                if (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval && !playerScript.dead)
                {
                    Shoot();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void LookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0;        
    }

    void Shoot()
    {
        if (renderer.isVisible)
        {
            //Reset the time when we shoot
            shotTime = Time.time;
            Projectile temp = Instantiate(enemyProjectile, transform.position + (target.position - transform.position).normalized, transform.rotation);
            temp.shotgun = false;
            temp.lifetime = 2f;
            temp.enemyProjectile = true;
            Vector2 bulletPosition = new Vector2(temp.transform.position.x, temp.transform.position.y);
            temp.speed = 6.0f;
            temp.xOffset = (float)random.NextDouble() * 0.1f;
            temp.yOffset = (float)random.NextDouble() * 0.1f;
            temp.bullet = temp.transform;
            temp.player = target.transform;
        }
    }

    public void SpawnDrop()
    {
        int drops = 1;
        if (playerScript.machinegunOwned || playerScript.machinegunOwned || playerScript.smartBombOwned || playerScript.shotgunOwned)
        {
            drops = 2;
        }
        switch (drops)
        {
            case 1:
                int random = Random.Range(0, 5);
                Debug.Log(random);
                if (random >= 4)
                {
                    SpawnDroppedItem(moneyPrefab);
                }
                break;
            case 2:
                random = Random.Range(0, 6);
                Debug.Log(random);
                if (random == 4 || random == 5)
                {
                    SpawnDroppedItem(moneyPrefab);
                }
                else if (random == 6)
                {
                    SpawnDroppedItem(bulletPrefab);
                }
                break;
            default:
                break;
        }
    }

    void SpawnDroppedItem(GameObject droppedItem)
    {
        float xOffset = Random.Range(-1, 1);
        float yOffset = Random.Range(-1, 1);
        var drop = Instantiate(droppedItem, transform.position + new Vector3(xOffset, yOffset, 0), Quaternion.identity);
        drop.transform.parent = GameObject.FindGameObjectWithTag("Map").transform;
    }
}
