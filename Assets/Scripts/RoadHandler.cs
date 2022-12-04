using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadHandler : MonoBehaviour
{
    public GameObject road;
    public List<GameObject> roadList;
    [SerializeField] private Transform mainCar;

    // Update is called once per frame
    void Update()
    {
        while(GameManager.lastRoadPositionZ <= mainCar.position.z + 100)
        {
            roadList.Add(Instantiate(road, new Vector3(0, 0, GameManager.lastRoadPositionZ + 20), Quaternion.identity) as GameObject);
            GameManager.lastRoadPositionZ += 20;
        }
        while (mainCar.position.z - roadList[0].transform.position.z> 100)
        {
            Debug.Log("Prock");
            GameObject temp = roadList[0];
            roadList.RemoveAt(0);
            Destroy(temp);
        }
    }
}
