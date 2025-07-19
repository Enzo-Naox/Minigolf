using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public InputActionReference EscapeAction;
    public List<InputActionReference> Actions;
    private bool isPaused = false;
    public keepEnableInput keepEnableInput;
    public FoundKeepEnableInput keepEnableInputOverride;

    void Awake()
    {
        // Initialisation
        Cursor.lockState = CursorLockMode.Locked;
        PausePanel.SetActive(false);
        keepEnableInputOverride.setKeepEnableInput();
        if (keepEnableInputOverride.GetKeepEnableInput())
        {
            keepEnableInput = keepEnableInputOverride.GetKeepEnableInput();
        }

        if (EscapeAction != null)
        {
            if (!keepEnableInput.getControleInput())
            {
                EscapeAction.action.Disable();
            }
            else
            {
                EscapeAction.action.Enable();
            }
            
            EscapeAction.action.performed += TogglePause; // Appeler TogglePause lorsque Escape est pressé
        }
    }

    private void TogglePause(InputAction.CallbackContext ctx)
    {
        isPaused = !isPaused; // Inverse l'état de pause

        if (isPaused)
        {
            // Activer le menu de pause
            Cursor.lockState = CursorLockMode.None;
            PausePanel.SetActive(true);
            ManageAction(true);
            Time.timeScale = 0;
        }
        else
        {
            // Désactiver le menu de pause
            Cursor.lockState = CursorLockMode.Locked;
            PausePanel.SetActive(false);
            ManageAction(false);
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        // Fonction appelée depuis un bouton pour quitter le menu de pause
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        PausePanel.SetActive(false);
    }

    private void OnDestroy()
    {
        // Désinscription des événements
        if (EscapeAction != null)
        {
            EscapeAction.action.performed -= TogglePause;
        }
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
