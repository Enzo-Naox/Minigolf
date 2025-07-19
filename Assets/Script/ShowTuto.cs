using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowTuto : MonoBehaviour
{
    public InputActionReference HAction;
    public GameObject Tutoriel;
    private bool isCanvasVisible = true;

    private void Start()
    {
        if (HAction != null)
        {
            HAction.action.Enable();
            HAction.action.performed += ToggleCanvas; // Appelle la m�thode � chaque appui
        }
    }

    private void ToggleCanvas(InputAction.CallbackContext ctx)
    {
        isCanvasVisible = !isCanvasVisible; // Alterne l'�tat
        Tutoriel.gameObject.SetActive(isCanvasVisible); // Active ou d�sactive Tutoriel
    }

    private void OnDestroy()
    {
        // D�sabonne l'�v�nement pour �viter des erreurs apr�s la destruction de l'objet
        if (HAction != null)
        {
            HAction.action.performed -= ToggleCanvas;
        }
    }
}
