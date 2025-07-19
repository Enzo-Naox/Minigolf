using UnityEngine;

public class CamSwap : MonoBehaviour
{
    public GameObject ball; // Assurez-vous de lier l'objet "Ball" via l'inspecteur
    public GameObject playerCamera; // Assurez-vous de lier la caméra "Cam_Player" via l'inspecteur
    private Rigidbody ballRigidbody;

    void Start()
    {
        // Récupérer le Rigidbody de la balle au début
        if (ball != null)
        {
            ballRigidbody = ball.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (ballRigidbody != null && playerCamera != null)
        {
            // Vérifier si la balle bouge
            if (ballRigidbody.velocity.magnitude >= 0.1f)
            {
                playerCamera.SetActive(false); // Désactiver la caméra si la balle bouge
            }
            else
            {
                playerCamera.SetActive(true); // Activer la caméra si la balle est immobile
            }
        }
    }
}
