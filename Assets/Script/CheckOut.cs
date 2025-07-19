using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{
    private Vector3 initialPosition; // Stocke la position d'origine de la balle

    void Start()
    {
        // Stocke la position initiale de l'objet au d�but
        initialPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
         //V�rifie si l'objet touch� a le tag "sol"
        if (collision.gameObject.CompareTag("Sol"))
        {
             //Remet la balle � sa position initiale
            transform.position = initialPosition;

             //Optionnel : Arr�te le mouvement en r�initialisant la v�locit� si un Rigidbody est utilis�
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    public void resetBallPosition()
    {
        transform.position = initialPosition;

        //Optionnel : Arr�te le mouvement en r�initialisant la v�locit� si un Rigidbody est utilis�
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
