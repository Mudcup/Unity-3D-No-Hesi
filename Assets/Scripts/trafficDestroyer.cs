using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficDestroyer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager.lastRoadPositionZ < this.transform.position.z || GameManager.backRoadPositionZ > this.transform.position.z)
        {
            Debug.Log("DELETED");
            Destroy(gameObject);
        }
    }
}
