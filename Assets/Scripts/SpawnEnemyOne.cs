using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOne : MonoBehaviour
{
    GameObject Player;
    public GameObject EnemyPrefab;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector2.Distance(transform.position, Player.transform.position));
        
        if(Vector2.Distance(transform.position, Player.transform.position) < 10)
        {
            Instantiate(EnemyPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            gameObject.SetActive(false);
        }
        
    }
}
