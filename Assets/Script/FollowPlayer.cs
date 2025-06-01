using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform player;
    void Start()
    {
       player = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
