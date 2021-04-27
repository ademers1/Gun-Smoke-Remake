using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class EnemyAILeave : MonoBehaviour
{

    public AIDestinationSetter setter;
    float rendererCountDown = 0;
    float rendererTimer;
    bool shouldFlee = false;
    public bool isFleeing = false;
    SpriteRenderer renderer;
    PlayerScript playerScript;

    LayerMask layerMask;

    // Start is called before the first frame update
    private void Awake()
    {
        rendererTimer = Random.Range(4, 8);
        Debug.Log(rendererTimer);
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        setter.target = playerScript.gameObject.transform;
        layerMask = LayerMask.GetMask("Obstacle");
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible)
        {
            rendererCountDown += Time.deltaTime;
        }
        if (playerScript.dead)
        {
            setter.enabled = false;
        }
        else if(!setter.enabled)
        {
            setter.enabled = true;
        }
        if(rendererCountDown >= 5)
        {
            isFleeing = true;
        }
        if (isFleeing)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 100, layerMask);
            Debug.DrawRay(transform.position, Vector2.left + new Vector2(-100,0), Color.red);
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 100, layerMask);
            RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, 100, layerMask);
            RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, 100, layerMask);
            Debug.Log("Collided With: " + hitLeft.collider);
            if (hitLeft.collider == null)
            {
                setter.enabled = false;
                float step = 3.5f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-10, 0, 0), step);

            }
            else if (hitRight.collider == null)
            {
                setter.enabled = false;
                float step = 3.5f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(10, 0, 0), step);
            }
            else if (hitDown.collider == null)
            {
                setter.enabled = false;
                float step = 3.5f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, -10, 0), step);

            }
            else if (hitUp.collider == null)
            {
                setter.enabled = false;
                float step = 3.5f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 10, 0), step);
            }
        }
    }
}
