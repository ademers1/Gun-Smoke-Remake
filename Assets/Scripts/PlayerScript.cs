using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject map;
    public GameObject map2;
    public AudioSource music;
    public Text deathText;
    public GameObject deathImage;

    public enum GunEquipped { normal = 0, shotgun = 1, machinegun = 2, magnum = 3, smartbomb = 4 }
    private enum FireDirection {  left = -1, straight = 0, right = 1}

    private FireDirection fireDirection = FireDirection.straight;

    public float speed;

    Animator anim;

    public Text scoreText;

    public Transform spawnPosition;

    public PlayerScript playerScript;

    bool firingRight;
    bool firingRightAgain;
    bool coroutineFinished = false;
    
    bool notInvoked;

    public int health = 1;

    float nextDirectionFire = 0f;
    float changeDirectionRate = 0.15f;
    float nextWalkingReset = 0f;
    float resetWalkingAnimationTime = 0.25f;

    public int fireRange = 0;
    public int score = 6500;
    public int ammo = 0;
    public int boots = 0;
    public int lives = 3;

    public bool shotgunOwned = false;
    public bool machinegunOwned = false;
    public bool magnumOwned = false;
    public bool smartBombOwned = false;
    public bool gunOwned = false;

    public bool posterCollected;

    public int machineGunAmmo = 0;
    public int magnumAmmo = 0;
    public int smartbombAmmo = 0;
    public int shotgunAmmo = 0;

    float fireRate = 0.1f;
    float nextFire = 0f;

    bool firedRecently = false;
    public bool dead = false;
    public int equippedGun = 0;
    GameObject bullet;
    Gun gun;
    Shotgun shotgun;
    // Start is called before the first frame update
    void Start()
    {
        if (speed <= 0)
        {
            speed = 5.0f;

            Debug.Log("Speed not set on " + name + ". Defaulting to " + speed);
        }

        anim = GetComponent<Animator>();

        map = GameObject.FindGameObjectWithTag("Map");
        spawnPosition = this.transform;
        gun = GetComponentInChildren<Gun>();
        shotgun = GetComponentInChildren<Shotgun>();
    }

    // Update is called once per frame
    void Update()
    {
        GunOwned();
        if (boots == 0)
        {
            speed = 5;
        }
        if (boots == 1)
        {
            speed = 6;
        }
        if (boots == 2)
        {
            speed = 7;
        }
        if (boots == 3)
        {
            speed = 8;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !dead)
        {
            this.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !dead)
        {
            this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow) && this.transform.position.y < 3.6 && !dead)
        {
            this.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.DownArrow) && this.transform.position.y > -4.3 && !dead)
        {
            this.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

        
        if (equippedGun != 2)
        {
            if (Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.X) && (Time.time > nextDirectionFire || fireDirection == FireDirection.straight))
            {
                fireDirection = FireDirection.straight;
                UpdateDirectionalTimers();
                anim.SetInteger("Shooting", (int)fireDirection);
                if (equippedGun == 1)
                {
                    shotgun.FireShotgunStraight(fireRange);
                }
                else
                {
                    gun.FireStraight(fireRange);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Z) && (Time.time > nextDirectionFire || fireDirection == FireDirection.left))
            {
                fireDirection = FireDirection.left;
                UpdateDirectionalTimers();
                anim.SetInteger("Shooting", (int)fireDirection);
                if (equippedGun == 1)
                {
                    shotgun.FireShotgunLeft(fireRange);
                }
                else
                {
                    gun.FireLeft(fireRange);
                }
            }
            else if (Input.GetKeyDown(KeyCode.X) && (Time.time > nextDirectionFire || fireDirection == FireDirection.right))
            {
                fireDirection = FireDirection.right;
                UpdateDirectionalTimers();
                anim.SetInteger("Shooting", (int)fireDirection);
                if(equippedGun == 1)
                {
                    shotgun.FireShotgunRight(fireRange);
                }
                else
                {
                    gun.FireRight(fireRange);
                }
            }
        }
        else
        {         
            if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.X) && Time.time > nextFire && (Time.time > nextDirectionFire || fireDirection == FireDirection.straight))
            {
                fireDirection = FireDirection.straight;
                UpdateDirectionalTimers();
                nextFire = Time.time + fireRate;
                anim.SetInteger("Shooting", (int)fireDirection);
                gun.FireStraight(fireRange);
                
            }
            else if (Input.GetKey(KeyCode.Z) && Time.time > nextFire && (Time.time > nextDirectionFire || fireDirection == FireDirection.left))
            {
                fireDirection = FireDirection.left;
                UpdateDirectionalTimers();
                nextFire = Time.time + fireRate;
                anim.SetInteger("Shooting", (int)fireDirection);
                gun.FireLeft(fireRange);
                
            }
            else if (Input.GetKey(KeyCode.X) && Time.time > nextFire && (Time.time > nextDirectionFire || fireDirection == FireDirection.right))
            {
                fireDirection = FireDirection.right;
                UpdateDirectionalTimers();
                nextFire = Time.time + fireRate;
                anim.SetInteger("Shooting", (int)fireDirection);
                gun.FireRight(fireRange);            
            }
        }

        if ((transform.position.y > 3.9 || transform.position.y < -4.6 || health == 0) && !dead)
        {
            dead = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject o in enemies)
            {
                o.GetComponentInChildren<Animate>().aiPath.canMove = false;
            }
            if (equippedGun != 0)
            {
                GetComponent<SelectMenu>().UpdateSelectScreenText(equippedGun);
            }
            KillPlayer();
        }

        if(Time.time > nextWalkingReset)
        {
            anim.SetInteger("Shooting", -2);
        }
    }

    public void UpdateDirectionalTimers()
    {
        nextDirectionFire = Time.time + changeDirectionRate;
        nextWalkingReset = Time.time + resetWalkingAnimationTime;
    }

    public void UpdateScore()
    {
        scoreText.text = "";
        int zerosToShow = 6;
        string scoreTextStr = score.ToString();
        zerosToShow = zerosToShow - scoreTextStr.Length;
        for (int i = 0; i < zerosToShow; i++)
        {
            scoreText.text += "0";
        }
        scoreText.text += score.ToString();
    }

    public void KillPlayer()
    {
        map.GetComponent<CameraMovement>().speed = 0;
        if (map2)
        {
            map2.GetComponent<CameraMovement>().speed = 0;
        }
        lives -= 1;
        
        deathText.text = "x " + lives.ToString();

        FindObjectOfType<AudioHandler>().Play("PlayerDeath");
        music.Stop();
        Debug.Log(lives);
        anim.SetBool("IsDead", true);
        if (lives > 0)
        {
            Invoke("DestroyPlayer", 3.0f);
        }
        else
        {
            Invoke("GameOver", 3.0f);
        }
    }

    public void DestroyPlayer()
    {
        deathImage.SetActive(true);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject o in enemies)
        {
            Destroy(o);
        }
        //this.gameObject.transform.position = spawnPosition.position;
        this.gameObject.transform.position = new Vector3(-0.5f, -3.3f, -5);
        Invoke("RespawnPlayer", 2.0f);
        this.gameObject.SetActive(false);
    }

    public void RespawnPlayer()
    {

        health = 1;
        this.gameObject.SetActive(true);
        deathImage.SetActive(false);
        music.Play();
        Invoke("ResumeMapMovement", 1.0f);
        dead = false;
        
    }

    public void ResumeMapMovement()
    {
        map.GetComponent<CameraMovement>().speed = 1.5f;
        if (map2 != null)
        {
            map2.GetComponent<CameraMovement>().speed = 1.5f;
        }
    }

    void GunOwned()
    {
        if (magnumOwned || shotgunOwned || smartBombOwned || machinegunOwned)
        {
            gunOwned = true;
        }
        else
        {
            gunOwned = false;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
