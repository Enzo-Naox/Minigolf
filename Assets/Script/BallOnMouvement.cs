using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOnMouvement : MonoBehaviour
{
    void Update()
    {
        if (GameObject.Find("Ball").GetComponent<Rigidbody>().velocity.magnitude >= 0.1)
        {
            GameObject.Find("Viseur").GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GameObject.Find("Viseur").GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
