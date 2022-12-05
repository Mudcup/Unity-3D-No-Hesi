using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class RoadHandler : MonoBehaviour
{
    public float carspawnrate;
    public float carspeedrate;
    public float initialspawnspeed;


    public GameObject road;
    public GameObject cone;
    public GameObject traffic;
    public Rigidbody player;


    public List<GameObject> roadList;
    public List<GameObject> coneList;
    public List<GameObject> carList;

    [SerializeField] private Transform mainCar;

    // Update is called once per frame
    void Update()
    {
        // make sure all tiles are rendered up to 200 units ahead of car
        while(GameManager.lastRoadPositionZ < mainCar.position.z + 200)
        {
            Debug.Log("Tile rendered ahead of Car");
            roadList.Add(Instantiate(road, new Vector3(0, 0, GameManager.lastRoadPositionZ + 20), Quaternion.identity) as GameObject);
            coneList.Add(Instantiate(cone, new Vector3(Random.Range(-8.0f, 8.0f), 0, GameManager.lastRoadPositionZ + 20), Quaternion.identity) as GameObject);
            


            if (Random.Range(0, 10) < carspawnrate && player.velocity.magnitude > initialspawnspeed)
            {
                GameObject tempcar;

                carList.Add( tempcar = Instantiate(traffic, new Vector3(Random.Range(-8.0f, 8.0f), 0, GameManager.lastRoadPositionZ ), Quaternion.identity) as GameObject);
                tempcar.GetComponent<Rigidbody>().velocity = player.velocity * carspeedrate;
                tempcar.GetComponent<trafficestroyer>().player = player.transform;
            }

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
            GameObject tempcone = coneList[coneList.Count - 1];
            roadList.RemoveAt(roadList.Count-1);
            coneList.RemoveAt(coneList.Count - 1);
            Destroy(temp);
            Destroy(tempcone);
            GameManager.lastRoadPositionZ -= 20;
        }

        // remove all tiles if over 100 units behind car
        while (mainCar.position.z - GameManager.backRoadPositionZ > 120)
        {
            Debug.Log("Tile deleted behind car");
            GameObject temp = roadList[0];
            GameObject tempcone = coneList[0];
            roadList.RemoveAt(0);
            coneList.RemoveAt(0);
            Destroy(temp);
            Destroy(tempcone);
            GameManager.backRoadPositionZ += 20;
        }
    }
}
