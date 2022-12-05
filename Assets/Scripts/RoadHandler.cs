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
        // make sure all tiles are rendered up to 200 units ahead of car
        while(GameManager.lastRoadPositionZ < mainCar.position.z + 200)
        {
            Debug.Log("Tile rendered ahead of Car");
            roadList.Add(Instantiate(road, new Vector3(0, 0, GameManager.lastRoadPositionZ + 20), Quaternion.identity) as GameObject);
            GameManager.lastRoadPositionZ += 20;
        }

        // make sure all tiles are rendered up to 100 units behind car
        while(GameManager.backRoadPositionZ > mainCar.position.z - 100)
        {
            Debug.Log("Tile rendered behind Car");
            roadList.Insert(0, Instantiate(road, new Vector3(0, 0, GameManager.backRoadPositionZ + 20), Quaternion.identity) as GameObject);
            GameManager.backRoadPositionZ -= 20;
        }

        // remove all tiles if over 200 unites ahead of car
        while (GameManager.lastRoadPositionZ - mainCar.position.z > 240)
        {
            Debug.Log("Tile deleted ahead of car");
            GameObject temp = roadList[roadList.Count - 1];
            roadList.RemoveAt(roadList.Count-1);
            Destroy(temp);
            GameManager.lastRoadPositionZ -= 20;
        }

        // remove all tiles if over 100 units behind car
        while (mainCar.position.z - GameManager.backRoadPositionZ > 120)
        {
            Debug.Log("Tile deleted behind car");
            GameObject temp = roadList[0];
            roadList.RemoveAt(0);
            Destroy(temp);
            GameManager.backRoadPositionZ += 20;
        }
    }
}
