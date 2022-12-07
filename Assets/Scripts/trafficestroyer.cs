using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficestroyer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Car").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z-this.transform.position.z > 200)
        {
           Destroy(gameObject);
        }
    }
}
