using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class conescript : MonoBehaviour
{

    public float slowdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.currCollisions++;
            if(GameManager.currCollisions >= GameManager.maxCollisions)
            {
                GameManager.finalScore = other.gameObject.transform.position.z.ToString("0.00");
                //Debug.Log("Final Score: " + GameManager.finalScore + "\n");
                SceneManager.LoadScene("GameOver");
            }
            //Debug.Log("Number of Collisions: " + GameManager.currCollisions + "\n");

            other.attachedRigidbody.velocity = other.attachedRigidbody.velocity * slowdown;
            other.GetComponent<CarController>().thetimerstarter();
            Destroy(this.gameObject);
        }
    }
}
