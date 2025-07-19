using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour
{
    private Vector3 initialPosition; // Stocke la position d'origine de la balle

    void Start()
    {
        // Stocke la position initiale de l'objet au début
        initialPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
         //Vérifie si l'objet touché a le tag "sol"
        if (collision.gameObject.CompareTag("Sol"))
        {
             //Remet la balle à sa position initiale
            transform.position = initialPosition;

             //Optionnel : Arrête le mouvement en réinitialisant la vélocité si un Rigidbody est utilisé
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

        //Optionnel : Arrête le mouvement en réinitialisant la vélocité si un Rigidbody est utilisé
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
