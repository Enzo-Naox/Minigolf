using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CloseTuto : MonoBehaviour
{
    public GameObject tutoriels; // L'objet contenant les tutoriels.
    public List<InputActionReference> Actions; // Liste des actions à activer/désactiver.
    public keepEnableInput keepEnableInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        ManageAction(true);
    }

    // Méthode appelée pour masquer les tutoriels.
    public void HideTuto()
    {
        tutoriels.SetActive(false); // Masquer les tutoriels.
        ManageAction(false); // Activer les contrôles.
        Cursor.lockState = CursorLockMode.Locked;
        keepEnableInput.setControleInput(true);
    }

    // Gérer l'état des actions.
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
