using UnityEngine;

public class CamSwap : MonoBehaviour
{
    public GameObject ball; // Assurez-vous de lier l'objet "Ball" via l'inspecteur
    public GameObject playerCamera; // Assurez-vous de lier la cam�ra "Cam_Player" via l'inspecteur
    private Rigidbody ballRigidbody;

    void Start()
    {
        // R�cup�rer le Rigidbody de la balle au d�but
        if (ball != null)
        {
            ballRigidbody = ball.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (ballRigidbody != null && playerCamera != null)
        {
            // V�rifier si la balle bouge
            if (ballRigidbody.velocity.magnitude >= 0.1f)
            {
                playerCamera.SetActive(false); // D�sactiver la cam�ra si la balle bouge
            }
            else
            {
                playerCamera.SetActive(true); // Activer la cam�ra si la balle est immobile
            }
        }
    }
}
