using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class EndCinematique : MonoBehaviour
{
    public CinemachineDollyCart dollyCart; // Le dolly qui suit le chemin
    public GameObject playerCamera;       // La cam�ra du joueur
    public GameObject cinematiqueCamera;  // La cam�ra actuelle (cin�matique)
    public List<InputActionReference> Actions;

    void Update()
    {
        // V�rifie si le dolly a atteint la fin du chemin
        if (dollyCart.m_Position >= dollyCart.m_Path.PathLength)
        {
            SwitchToPlayerCamera();
        }
    }

    private void SwitchToPlayerCamera()
    {
        // D�sactive la cam�ra cin�matique
        if (cinematiqueCamera != null)
        {
            cinematiqueCamera.SetActive(false);
        }

        // Active la cam�ra du joueur
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
