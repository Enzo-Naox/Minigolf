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
            HAction.action.performed += ToggleCanvas; // Appelle la méthode à chaque appui
        }
    }

    private void ToggleCanvas(InputAction.CallbackContext ctx)
    {
        isCanvasVisible = !isCanvasVisible; // Alterne l'état
        Tutoriel.gameObject.SetActive(isCanvasVisible); // Active ou désactive Tutoriel
    }

    private void OnDestroy()
    {
        // Désabonne l'événement pour éviter des erreurs après la destruction de l'objet
        if (HAction != null)
        {
            HAction.action.performed -= ToggleCanvas;
        }
    }
}
