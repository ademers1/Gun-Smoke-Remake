using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public PlayerScript playerScript;

    public Transform rightSpawnPoint1;
    public Transform rightSpawnPoint2;
    public Transform rightSpawnPoint3;
    public Transform rightSpawnPoint4;
    public Transform rightSpawnPoint5;


    public Transform leftSpawnPoint1;
    public Transform leftSpawnPoint2;
    public Transform leftSpawnPoint3;
    public Transform leftSpawnPoint4;
    public Transform leftSpawnPoint5;

    public Transform straightSpawnPoint1;
    public Transform straightSpawnPoint2;
    public Transform straightSpawnPoint3;
    public Transform straightSpawnPoint4;
    public Transform straightSpawnPoint5;

    public Projectile shotgunProjectilePrefab;


    public float shotgunXSpeed5;
    public float shotgunYSpeed1;
    public float shotgunXYSpeed24;
    public float shotgunYXSpeed24;
    public float shotgunXYSpeed3;

    public float strShotgunYSpeed51;
    public float strShotgunXSpeed51;
    public float strShotgunXSpeed24;
    public float strShotgunYSpeed3;
    public float strShotgunYSpeed24;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireShotgunRight(int fireRange)
    {
        Projectile temp1 = Instantiate(shotgunProjectilePrefab, rightSpawnPoint1.position, rightSpawnPoint1.rotation);
        Projectile temp2 = Instantiate(shotgunProjectilePrefab, rightSpawnPoint2.position, rightSpawnPoint2.rotation);
        Projectile temp3 = Instantiate(shotgunProjectilePrefab, rightSpawnPoint3.position, rightSpawnPoint3.rotation);
        Projectile temp4 = Instantiate(shotgunProjectilePrefab, rightSpawnPoint4.position, rightSpawnPoint4.rotation);
        Projectile temp5 = Instantiate(shotgunProjectilePrefab, rightSpawnPoint5.position, rightSpawnPoint5.rotation);

        temp1.shotgun = true;
        temp2.shotgun = true;
        temp3.shotgun = true;
        temp4.shotgun = true;
        temp5.shotgun = true;

        temp1.xVelocity = 0;
        temp1.yVelocity = shotgunYSpeed1;

        temp2.xVelocity = shotgunXYSpeed24;
        temp2.yVelocity = shotgunYXSpeed24;

        temp3.xVelocity = shotgunXYSpeed3;
        temp3.yVelocity = shotgunXYSpeed3;

        temp4.xVelocity = shotgunYXSpeed24;
        temp4.yVelocity = shotgunXYSpeed24;

        temp5.xVelocity = shotgunXSpeed5;
        temp5.yVelocity = 70;

        if (fireRange == 1)
        {
            temp1.lifetime = 0.15f;
            temp2.lifetime = 0.15f;
            temp3.lifetime = 0.15f;
            temp4.lifetime = 0.15f;
            temp5.lifetime = 0.15f;
        }
        if (fireRange == 2)
        {
            temp1.lifetime = 0.18f;
            temp2.lifetime = 0.18f;
            temp3.lifetime = 0.18f;
            temp4.lifetime = 0.18f;
            temp5.lifetime = 0.18f;
        }
        if (fireRange == 3)
        {
            temp1.lifetime = 0.2f;
            temp2.lifetime = 0.2f;
            temp3.lifetime = 0.2f;
            temp4.lifetime = 0.2f;
            temp5.lifetime = 0.2f;
        }
        FindObjectOfType<AudioHandler>().Play("Shoot");
    }

    public void FireShotgunLeft(int fireRange)
    {
        Projectile temp1 = Instantiate(shotgunProjectilePrefab, leftSpawnPoint1.position, leftSpawnPoint1.rotation);
        Projectile temp2 = Instantiate(shotgunProjectilePrefab, leftSpawnPoint2.position, leftSpawnPoint2.rotation);
        Projectile temp3 = Instantiate(shotgunProjectilePrefab, leftSpawnPoint3.position, leftSpawnPoint3.rotation);
        Projectile temp4 = Instantiate(shotgunProjectilePrefab, leftSpawnPoint4.position, leftSpawnPoint4.rotation);
        Projectile temp5 = Instantiate(shotgunProjectilePrefab, leftSpawnPoint5.position, leftSpawnPoint5.rotation);

        temp1.shotgun = true;
        temp2.shotgun = true;
        temp3.shotgun = true;
        temp4.shotgun = true;
        temp5.shotgun = true;

        temp1.xVelocity = 0;
        temp1.yVelocity = shotgunYSpeed1;

        temp2.xVelocity = -shotgunXYSpeed24;
        temp2.yVelocity = shotgunYXSpeed24;

        temp3.xVelocity = -shotgunXYSpeed3;
        temp3.yVelocity = shotgunXYSpeed3;

        temp4.xVelocity = -shotgunYXSpeed24;
        temp4.yVelocity = shotgunXYSpeed24;

        temp5.xVelocity = -shotgunXSpeed5;
        temp5.yVelocity = 70;

        if (fireRange == 1)
        {
            temp1.lifetime = 0.15f;
            temp2.lifetime = 0.15f;
            temp3.lifetime = 0.15f;
            temp4.lifetime = 0.15f;
            temp5.lifetime = 0.15f;
        }
        if (fireRange == 2)
        {
            temp1.lifetime = 0.18f;
            temp2.lifetime = 0.18f;
            temp3.lifetime = 0.18f;
            temp4.lifetime = 0.18f;
            temp5.lifetime = 0.18f;
        }
        if (fireRange == 3)
        {
            temp1.lifetime = 0.2f;
            temp2.lifetime = 0.2f;
            temp3.lifetime = 0.2f;
            temp4.lifetime = 0.2f;
            temp5.lifetime = 0.2f;
        }
        FindObjectOfType<AudioHandler>().Play("Shoot");
    }

    public void FireShotgunStraight(int fireRange)
    {
        Projectile temp1 = Instantiate(shotgunProjectilePrefab, straightSpawnPoint1.position, straightSpawnPoint1.rotation);
        Projectile temp2 = Instantiate(shotgunProjectilePrefab, straightSpawnPoint2.position, straightSpawnPoint2.rotation);
        Projectile temp3 = Instantiate(shotgunProjectilePrefab, straightSpawnPoint3.position, straightSpawnPoint3.rotation);
        Projectile temp4 = Instantiate(shotgunProjectilePrefab, straightSpawnPoint4.position, straightSpawnPoint4.rotation);
        Projectile temp5 = Instantiate(shotgunProjectilePrefab, straightSpawnPoint5.position, straightSpawnPoint5.rotation);

        temp1.shotgun = true;
        temp2.shotgun = true;
        temp3.shotgun = true;
        temp4.shotgun = true;
        temp5.shotgun = true;

        temp1.xVelocity = strShotgunXSpeed51;
        temp1.yVelocity = strShotgunYSpeed51;

        temp2.xVelocity = strShotgunXSpeed24;
        temp2.yVelocity = strShotgunYSpeed24;

        temp3.xVelocity = 0;
        temp3.yVelocity = strShotgunYSpeed3;

        temp4.xVelocity = -strShotgunXSpeed24;
        temp4.yVelocity = strShotgunYSpeed24;

        temp5.xVelocity = -strShotgunXSpeed51;
        temp5.yVelocity = strShotgunYSpeed51;

        if (fireRange == 1)
        {
            temp1.lifetime = 0.15f;
            temp2.lifetime = 0.15f;
            temp3.lifetime = 0.15f;
            temp4.lifetime = 0.15f;
            temp5.lifetime = 0.15f;
        }
        if (fireRange == 2)
        {
            temp1.lifetime = 0.18f;
            temp2.lifetime = 0.18f;
            temp3.lifetime = 0.18f;
            temp4.lifetime = 0.18f;
            temp5.lifetime = 0.18f;
        }
        if (fireRange == 3)
        {
            temp1.lifetime = 0.2f;
            temp2.lifetime = 0.2f;
            temp3.lifetime = 0.2f;
            temp4.lifetime = 0.2f;
            temp5.lifetime = 0.2f;
        }
        FindObjectOfType<AudioHandler>().Play("Shoot");
    }

}
