using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CloseTuto : MonoBehaviour
{
    public GameObject tutoriels; // L'objet contenant les tutoriels.
    public List<InputActionReference> Actions; // Liste des actions � activer/d�sactiver.
    public keepEnableInput keepEnableInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        ManageAction(true);
    }

    // M�thode appel�e pour masquer les tutoriels.
    public void HideTuto()
    {
        tutoriels.SetActive(false); // Masquer les tutoriels.
        ManageAction(false); // Activer les contr�les.
        Cursor.lockState = CursorLockMode.Locked;
        keepEnableInput.setControleInput(true);
    }

    // G�rer l'�tat des actions.
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
