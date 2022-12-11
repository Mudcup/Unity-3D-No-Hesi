using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class conescript : MonoBehaviour
{
    public GameObject prevCone = null;
    public float slowdown;
    public Collider lastPointTouched;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<Transform>().position.z < 1 && other.gameObject.GetComponent<Transform>().position.z > -1)
            {
                Destroy(this.gameObject);
                return;
            }
            if (other == lastPointTouched && other.gameObject.activeSelf) //Check to see if collider is the same as previous
                return;

            lastPointTouched = other;

            if (prevCone == null && other.gameObject.activeSelf) //Check to see if first cone hit
            {
                GameManager.currCollisions++;
                Debug.Log("Cone hit");
            }
            else if (prevCone.transform.position != this.gameObject.transform.position && other.gameObject.activeSelf) //Check to see if same cone hit
            {
                GameManager.currCollisions++;
                Debug.Log("Cone hit");
            }

            prevCone = this.gameObject;

            if(GameManager.currCollisions >= GameManager.maxCollisions)
            {
                GameManager.finalScore = other.gameObject.transform.position.z.ToString("0.00");
                if(other.gameObject.transform.position.z > GameManager.highScore)
                {
                    GameManager.highScore = other.gameObject.transform.position.z;
                }
                //Debug.Log("Final Score: " + GameManager.finalScore + "\n");
                SceneManager.LoadScene("GameOver");
            }
            Debug.Log("Number of Collisions: " + GameManager.currCollisions + "\n");

            other.attachedRigidbody.velocity = other.attachedRigidbody.velocity * slowdown;
            other.GetComponent<CarController>().thetimerstarter();
            Destroy(this.gameObject);
        }
    }
}
