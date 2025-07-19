using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallPower : MonoBehaviour
{
    public int Puissance = 0; // Valeur de puissance initiale
    public int PuissanceMax = 1000; // Limite maximale de la puissance
    public int PuissanceIncrement = 10; // Incr�ment de puissance par frame
    public InputActionReference FireAction;
    public InputActionReference CancelAction;
    private bool isCharging = false; // Indique si le bouton est maintenu
    private Rigidbody ballRigidbody;
    public Transform arrowTransform; // R�f�rence � la fl�che
    public float arrowMaxScaleX = 3f; // Taille maximale de la fl�che
    public float arrowMaxScaleZ = 3f; // Taille maximale de la fl�che
    public Renderer arrowRenderer;
    public Color minChargeColor = Color.green;
    public Color maxChargeColor = Color.red;
    public TMP_Text TxtShots;
    public int shots = 0;
    public AudioSource shotAudioSource;
    private bool isCancel = false;
    public keepEnableInput keepEnableInput;
    public FoundKeepEnableInput keepEnableInputOverride;

    void Start()
    {
        GameObject ball = GameObject.Find("Ball");
        if (keepEnableInputOverride.GetKeepEnableInput())
        {
            keepEnableInput = keepEnableInputOverride.GetKeepEnableInput();
        }
        
        if (FireAction != null)
        {
            if (!keepEnableInput.getControleInput())
            {
                FireAction.action.Disable();
            }
            else
            {
                FireAction.action.Enable();
            }

            FireAction.action.performed += ctx => StartCharging();
            FireAction.action.canceled += ctx => ReleasePower();
        }

        if (ball != null)
        {
            ballRigidbody = ball.GetComponent<Rigidbody>();
        }

        if (CancelAction != null)
        {
            if (!keepEnableInput.getControleInput())
            {
                CancelAction.action.Disable();
            }
            else
            {
                CancelAction.action.Enable();
            }

            CancelAction.action.performed += ctx => CancelCharge();
        }
    }

    void Update()
    {
        // Augmenter la puissance si le bouton est maintenu
        if (isCharging)
        {
            Puissance = Mathf.Min(Puissance + PuissanceIncrement, PuissanceMax);

            if (arrowTransform != null)
            {
                float scaleX = Mathf.Lerp(1f, arrowMaxScaleX, (float)Puissance / PuissanceMax);
                float scaleZ = Mathf.Lerp(1f, arrowMaxScaleZ, (float)Puissance / PuissanceMax);
                arrowTransform.localScale = new Vector3(
                    scaleX,
                    arrowTransform.localScale.y,
                    scaleZ                       
                );
            }

            if (arrowRenderer != null)
            {
                float t = (float)Puissance / PuissanceMax; // Valeur entre 0 et 1
                arrowRenderer.material.color = Color.Lerp(minChargeColor, maxChargeColor, t);
            }
        }
        else if (arrowTransform != null)
        {
            // R�initialiser la fl�che lorsque l'on ne charge pas
            arrowTransform.localScale = new Vector3(
                1f,
                arrowTransform.localScale.y,
                1f
            );

            if (arrowRenderer != null)
            {
                arrowRenderer.material.color = minChargeColor;
            }
        }
    }

    void StartCharging()
    {
        isCharging = true; // Le bouton est maintenu
        Puissance = 0;     // R�initialiser la puissance au d�but du chargement
    }

    public void ReleasePower()
    {
        isCharging = false; // Arr�ter le chargement

        if (ballRigidbody != null && ballRigidbody.velocity.magnitude <= 0.1f && !isCancel)
        {
            // Appliquer la force � la balle dans la direction avant
            shotAudioSource.Play();
            ballRigidbody.AddForce(transform.TransformDirection(Vector3.forward) * Puissance);
            shots++;
            TxtShots.text = "" + shots;
            
        }

        // R�initialiser la puissance apr�s le tir
        Puissance = 0;
        isCancel = false;
    }

    void CancelCharge()
    {
        if (isCharging)
        {
            isCharging = false;
            isCancel = true;
            Puissance = 0;

            if (arrowTransform != null)
            {
                arrowTransform.localScale = new Vector3(
                    1f,
                    arrowTransform.localScale.y,
                    1f
                );
            }

            if (arrowRenderer != null)
            {
                arrowRenderer.material.color = minChargeColor;
            }
        }
    }

    private void OnDestroy()
    {
        if (FireAction != null)
        {
            FireAction.action.Disable();
            FireAction.action.performed -= ctx => StartCharging();
            FireAction.action.canceled -= ctx => ReleasePower();
        }

        if (CancelAction != null)
        {
            CancelAction.action.Disable();
            CancelAction.action.performed -= ctx => CancelCharge();
        }
    }
}
