using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Direction : MonoBehaviour
{
    public int SpeedRotation = 50;

    [Tooltip("Reference to the Look action from your Input System Action Map")]
    public InputActionReference LookAction;

    [Tooltip("Reference to the Right Click action from your Input System Action Map")]
    public InputActionReference RightClickAction;

    private Transform ballTransform;
    private bool isRightClicking = false;
    public keepEnableInput keepEnableInput;
    public FoundKeepEnableInput keepEnableInputOverride;

    void Start()
    {
        // Find and cache the ball's transform for efficiency
        ballTransform = GameObject.Find("Ball").GetComponent<Transform>();
        if (keepEnableInputOverride.GetKeepEnableInput())
        {
            keepEnableInput = keepEnableInputOverride.GetKeepEnableInput();
        }

        // Enable the Look action
        if (LookAction != null)
        {
            if (!keepEnableInput.getControleInput())
            {
                LookAction.action.Disable();
            }
            else
            {
                LookAction.action.Enable();
            }
        }
        else
        {
            Debug.LogError("LookAction is not assigned in the inspector.");
        }
        // Enable the RightClick action and set up listeners
        if (RightClickAction != null)
        {
            if (!keepEnableInput.getControleInput())
            {
                RightClickAction.action.Disable();
            }
            else
            {
                RightClickAction.action.Enable();
            }
            
            RightClickAction.action.performed += ctx => isRightClicking = true;
            RightClickAction.action.canceled += ctx => isRightClicking = false;
        }
        else
        {
            Debug.LogError("RightClickAction is not assigned in the inspector.");
        }
    }

    void Update()
    {
        if (ballTransform == null)
        {
            Debug.LogWarning("Ball object not found.");
            return;
        }

        // Make the object follow the Ball's position
        transform.position = ballTransform.position;

        // Only rotate if right click is held
        if (isRightClicking && LookAction != null)
        {
            Vector2 lookInput = LookAction.action.ReadValue<Vector2>();
            float rotationAmount = lookInput.x * SpeedRotation * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationAmount);
        }
    }

    private void OnDestroy()
    {
        // Clean up
        if (LookAction != null)
        {
            LookAction.action.Disable();
        }

        if (RightClickAction != null)
        {
            RightClickAction.action.Disable();
            RightClickAction.action.performed -= ctx => isRightClicking = true;
            RightClickAction.action.canceled -= ctx => isRightClicking = false;
        }
    }
}
