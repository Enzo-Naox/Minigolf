using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class EndCinematique : MonoBehaviour
{
    public CinemachineDollyCart dollyCart; // Le dolly qui suit le chemin
    public GameObject playerCamera;       // La caméra du joueur
    public GameObject cinematiqueCamera;  // La caméra actuelle (cinématique)
    public List<InputActionReference> Actions;

    void Update()
    {
        // Vérifie si le dolly a atteint la fin du chemin
        if (dollyCart.m_Position >= dollyCart.m_Path.PathLength)
        {
            SwitchToPlayerCamera();
        }
    }

    private void SwitchToPlayerCamera()
    {
        // Désactive la caméra cinématique
        if (cinematiqueCamera != null)
        {
            cinematiqueCamera.SetActive(false);
        }

        // Active la caméra du joueur
        if (playerCamera != null)
        {
            playerCamera.SetActive(true);
            ManageAction(false);
        }

        enabled = false;
    }

    private void ManageAction(bool state)
    {
        for (int i = 0; i < Actions.Count; i++)
        {
            if (state)
            {
                Actions[i].action.Disable();
            }
            else
            {
                Actions[i].action.Enable();
            }

        }
    }
}
