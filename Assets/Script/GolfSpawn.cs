using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class GolfSpawn : MonoBehaviour
{
    private List<Vector3> spawnPositions = new List<Vector3>(); // Stocker les positions de d�part
    private int animationsCompleted = 0; // Compteur des animations termin�es
    private bool allAnimationsDone = false; // Bool�en pour indiquer si toutes les animations sont termin�es
    public List<InputActionReference> Actions;

    public bool AllAnimationsDone => allAnimationsDone; // Propri�t� publique pour acc�der au bool�en

    void Awake()
    {
        // Stocker les positions initiales de tous les enfants
        foreach (Transform child in transform)
        {
            spawnPositions.Add(child.position);
        }
    }

    void Start()
    {
        ManageAction(true);
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            // Position de d�part pour l'animation (10 unit�s au-dessus)
            child.position = spawnPositions[i] + Vector3.up * 10f;

            // Animation avec d�lai progressif
            child.DOMove(spawnPositions[i], 1f) // Dur�e de l'animation
                .SetEase(Ease.OutQuart)         // Effet d'animation
                .SetDelay(i * 0.5f)            // D�lai progressif entre chaque enfant
                .OnComplete(() =>              // Callback lorsqu'une animation est termin�e
                {
                    animationsCompleted++;
                    if (animationsCompleted == transform.childCount)
                    {
                        allAnimationsDone = true; // Toutes les animations sont termin�es
                    }
                });
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
