using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conecounter : MonoBehaviour
{
    public List<GameObject> coneList;
    public int coneCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        coneList.Add(this.transform.GetChild(0).gameObject);
        coneList.Add(this.transform.GetChild(1).gameObject);
        coneList.Add(this.transform.GetChild(2).gameObject);
        coneList.Add(this.transform.GetChild(3).gameObject);
        coneList.Add(this.transform.GetChild(4).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteconeui()
    {
        if (coneList.Count > 0)
        {
            Destroy(coneList[coneCount].gameObject);
            coneCount++;
        }
    }

}
