using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject road;
    public List<GameObject> roadList;
    public int[] intArray;
    private float[] floatArray = new float[5];
    public bool[] booleanArray = new bool[3] { true, false, true };
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
     for(int i = 0; i < 4; i++)
        {
            roadList.Add(Instantiate(road, new Vector3(0,0,0), Quaternion.identity) as GameObject);
        }   

     foreach (GameObject o in roadList)
        {
            o.transform.position = new Vector3(0, 0, (GameManager.lastRoadPositionZ + 24));
            GameManager.lastRoadPositionZ += 24;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if(timer > 3.0)
        {
            for(int i = 0; i < 4; i++)
            {
                roadList.Add(Instantiate(road, new Vector3(0, 0, GameManager.lastRoadPositionZ + 24), Quaternion.identity) as GameObject);
                GameManager.lastRoadPositionZ += 24;
            }
        }

        timer = 0;
    }
}
