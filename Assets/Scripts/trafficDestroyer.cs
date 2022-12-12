using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using Random = UnityEngine.Random;


public class trafficDestroyer : MonoBehaviour
{
    [SerializeField] Material yellow;
    [SerializeField] Material purple;
    [SerializeField] Material red;
    [SerializeField] Material backLights;
    // Update is called once per frame
    public Transform rb;
    public int type;//0 1 or 2
    float xdis;
    float ydis;
    float moveforce;

    void Start()
    {
        type = Random.Range(0, 3);
        moveforce = 1000;
        Material[] myMaterials = new Material[2];
        myMaterials[1] = backLights;

        switch (type)
        {
            case 0:
                myMaterials[0] = yellow;
                this.transform.GetChild(0).GetComponent<MeshRenderer>().materials = myMaterials;//this.transform.GetChild(0).GetComponent<MeshRenderer>().materials[2];//does nothing
                break;
            case 1:
                myMaterials[0] = red;
                this.transform.GetChild(0).GetComponent<MeshRenderer>().materials = myMaterials;//this.transform.GetChild(0).GetComponent<MeshRenderer>().materials[3];//go away from you
                break;
            case 2:
                myMaterials[0] = purple;
                this.transform.GetChild(0).GetComponent<MeshRenderer>().materials = myMaterials;//this.transform.GetChild(0).GetComponent<MeshRenderer>().materials[4];//towards you
                break;

        }
        rb = GameObject.Find("Car").GetComponent<Transform>();
    }

    void Update()
    {
        if (GameManager.lastRoadPositionZ < this.transform.position.z || GameManager.backRoadPositionZ > this.transform.position.z)
        {
            Destroy(gameObject);
        }

        switch (type)
        {
            case 0:
               
                // code block
                break;
            case 1:
                

                xdis = this.GetComponent<Transform>().position.x - rb.position.x;
                ydis = this.GetComponent<Transform>().position.z - rb.position.z;

                if (ydis < 20)
                {
                    if (xdis < 8)
                    {
                        if (this.GetComponent<Transform>().position.x > rb.position.x)
                        {
                            this.GetComponent<Rigidbody>().AddForce(new Vector3(moveforce, 0, 0));
                                //move right
                        }
                        else
                        {
                            this.GetComponent<Rigidbody>().AddForce(new Vector3(-moveforce, 0, 0));

                            //move left
                        }
                    }
                }
                break;
            case 2:
                

                xdis = this.GetComponent<Transform>().position.x - rb.position.x;
                ydis = this.GetComponent<Transform>().position.z - rb.position.z;
                


                if (ydis < 20)
                {
                    if (xdis < 20)
                    {
                        if (this.GetComponent<Transform>().position.x > rb.position.x)
                        {
                            this.GetComponent<Rigidbody>().AddForce(new Vector3(-moveforce, 0, 0));

                            //move left
                        }
                        else
                        {
                            this.GetComponent<Rigidbody>().AddForce(new Vector3(moveforce, 0, 0));

                            //move right
                        }
                    }
                }
                break;

        }


    }
}
