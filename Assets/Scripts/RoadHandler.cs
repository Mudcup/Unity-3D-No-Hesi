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
    public GameObject barricade;
    public GameObject traffic;
    public Rigidbody player;


    public List<GameObject> roadList;
    public List<GameObject> obstacleList;
    public List<GameObject> carList;

    [SerializeField] private Transform mainCar;

    // Update is called once per frame
    void Update()
    {
        // make sure all tiles are rendered up to 200 units ahead of car
        while(GameManager.lastRoadPositionZ < mainCar.position.z + 200)
        {
            roadList.Add(Instantiate(road, new Vector3(0, 0, GameManager.lastRoadPositionZ + 20), Quaternion.identity) as GameObject);

            int coneOrBarricade = 0;
            coneOrBarricade = Random.Range(0, 5);
            Quaternion rot = new Quaternion(0,1,0, (float)Math.Sin(Math.PI/2));
            if(coneOrBarricade <= 2)
                obstacleList.Add(Instantiate(cone, new Vector3(Random.Range(-8.0f, 8.0f), 0, GameManager.lastRoadPositionZ + 20), Quaternion.identity) as GameObject);
            else
                obstacleList.Add(Instantiate(barricade, new Vector3(Random.Range(-8.0f, 8.0f), 0, GameManager.lastRoadPositionZ + 20), rot) as GameObject);


            if (Random.Range(0, 10) < carspawnrate && player.velocity.z > initialspawnspeed)
            {
                GameObject tempcar;

                carList.Add( tempcar = Instantiate(traffic, new Vector3(Random.Range(-8.0f, 8.0f), 0, GameManager.lastRoadPositionZ ), Quaternion.identity) as GameObject);
                tempcar.GetComponent<Rigidbody>().velocity = player.velocity * carspeedrate;
            }

            GameManager.lastRoadPositionZ += 20;
        }

        // make sure all tiles are rendered up to 100 units behind car
        while(GameManager.backRoadPositionZ > mainCar.position.z - 100)
        {
            roadList.Insert(0, Instantiate(road, new Vector3(0, 0, GameManager.backRoadPositionZ + 20), Quaternion.identity) as GameObject);
            GameManager.backRoadPositionZ -= 20;
        }

        // remove all tiles if over 200 unites ahead of car
        while (GameManager.lastRoadPositionZ - mainCar.position.z > 240)
        {
            GameObject temp = roadList[roadList.Count - 1];
            GameObject tempcone = obstacleList[obstacleList.Count - 1];
            roadList.RemoveAt(roadList.Count-1);
            obstacleList.RemoveAt(obstacleList.Count - 1);
            Destroy(temp);
            Destroy(tempcone);
            GameManager.lastRoadPositionZ -= 20;
        }

        // remove all tiles if over 100 units behind car
        while (mainCar.position.z - GameManager.backRoadPositionZ > 120)
        {
            GameObject temp = roadList[0];
            GameObject tempcone = obstacleList[0];
            roadList.RemoveAt(0);
            obstacleList.RemoveAt(0);
            Destroy(temp);
            Destroy(tempcone);
            GameManager.backRoadPositionZ += 20;
        }
    }
}
