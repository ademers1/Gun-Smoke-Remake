using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public CameraMovement gridPrefab;
    bool despawnedOldMap = false;
    bool shouldDespawn = true;
    PlayerScript playerScript;

    public GameObject map;
    public GameObject map2;
    // Start is called before the first frame update
    void Start()
    {
        if(speed == 0)
        {
            speed = 1.5f;

            Debug.Log("Speed not set for " + name + ". Defaulting to " + speed + ".");
        }
        map = this.gameObject;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        if(this.transform.position.y <= -170 && GameObject.FindGameObjectWithTag("Player") && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().posterCollected && shouldDespawn)
        {
            Debug.Log("testing");
            despawnedOldMap = true;
            SpawnNewGrid();
        }
        if(this.transform.position.y <= -190)
        {
            Destroy(gameObject);
            map = map2;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().map = map;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().map2 = null;
        }

        if (playerScript.posterCollected)
        {
            shouldDespawn = false;
        }

        if(this.transform.position.y <= -177.5 && !shouldDespawn)
        {
            speed = 0;
            StartCoroutine(EndGame());
        }
    }

    public void SpawnNewGrid()
    {
        CameraMovement temp = Instantiate(gridPrefab, new Vector3(0, 17.95f, 0), gridPrefab.transform.rotation);
        temp.speed = 1.5f;
        map2 = temp.gameObject;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().map2 = map2;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Win");
    }
}
