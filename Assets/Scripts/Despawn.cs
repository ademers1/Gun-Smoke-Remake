using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public EnemyAILeave leaveScript;
    public GameObject parent;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "DespawnBox" && leaveScript.isFleeing)
        {
            Destroy(parent);
        }
    }
}
