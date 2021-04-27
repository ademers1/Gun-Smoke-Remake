using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    PlayerScript playerScript;

    public Transform rightSpawnPoint1;
    public Transform rightSpawnPoint2;

    public Transform leftSpawnPoint1;
    public Transform leftSpawnPoint2;

    public Transform straightSpawnPoint1;
    public Transform straightSpawnPoint2;

    public Projectile rightProjectilePrefab;
    public Projectile leftProjectilePrefab;
    public Projectile straightProjectilePrefab;

    public float projectileSpeed;
    public float lowProjectileSpeed;
    public float highProjectileSpeed;

    public void Awake()
    {
        playerScript = GetComponentInParent<PlayerScript>();
    }

    public void FireRight(int fireRange)
    {
        //here we have to set the projectiles x velocity to be different as they spread out from each other
        Projectile temp = Instantiate(rightProjectilePrefab, rightSpawnPoint1.position,
            rightSpawnPoint1.rotation);

        temp.speed = projectileSpeed;

        Projectile temp2 = Instantiate(rightProjectilePrefab, rightSpawnPoint2.position,
            rightSpawnPoint2.rotation);

        temp.direction = 0;
        temp2.direction = 0;

        temp.speed = projectileSpeed;
        temp2.speed = projectileSpeed;

        temp.xVelocity = highProjectileSpeed;
        temp2.xVelocity = lowProjectileSpeed;
 

        if (fireRange == 1)
        {
            temp.lifetime = 0.15f;
        }
        if (fireRange == 2)
        {
            temp.lifetime = 0.18f;
        }
        if (fireRange == 3)
        {
            temp.lifetime = 0.2f;
        }
        FindObjectOfType<AudioHandler>().Play("Shoot");
    }
    public void FireStraight(int fireRange)
    {
        //yield return new WaitForSeconds(delay);
        Projectile temp = Instantiate(straightProjectilePrefab, straightSpawnPoint1.position,
            straightSpawnPoint2.rotation);

        temp.speed = projectileSpeed;

        Projectile temp2 = Instantiate(straightProjectilePrefab, straightSpawnPoint2.position,
            straightSpawnPoint2.rotation);

        temp.direction = 1;
        temp2.direction = 1;

        temp.speed = projectileSpeed;
        temp2.speed = projectileSpeed;

        if (fireRange == 1)
        {
            temp.lifetime = 0.25f;
        }
        if (fireRange == 2)
        {
            temp.lifetime = 0.3f;
        }
        if (fireRange == 3)
        {
            temp.lifetime = 0.35f;
        }
        FindObjectOfType<AudioHandler>().Play("Shoot");
    }
    public void FireLeft(int fireRange)
    {
        Projectile temp = Instantiate(leftProjectilePrefab, leftSpawnPoint1.position,
        leftSpawnPoint1.rotation);

        temp.speed = projectileSpeed;

        Projectile temp2 = Instantiate(leftProjectilePrefab, leftSpawnPoint2.position,
            leftSpawnPoint2.rotation);

        temp.direction = 2;
        temp2.direction = 2;

        temp.speed = projectileSpeed;
        temp2.speed = projectileSpeed;

        temp.xVelocity = highProjectileSpeed;
        temp2.xVelocity = lowProjectileSpeed;

        if (fireRange == 1)
        {
            temp.lifetime = 0.25f;
        }
        if (fireRange == 2)
        {
            temp.lifetime = 0.3f;
        }
        if (fireRange == 3)
        {
            temp.lifetime = 0.35f;
        }
        FindObjectOfType<AudioHandler>().Play("Shoot");       
    }
}
