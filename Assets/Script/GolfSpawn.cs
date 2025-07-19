using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class GolfSpawn : MonoBehaviour
{
    private List<Vector3> spawnPositions = new List<Vector3>(); // Stocker les positions de départ
    private int animationsCompleted = 0; // Compteur des animations terminées
    private bool allAnimationsDone = false; // Booléen pour indiquer si toutes les animations sont terminées
    public List<InputActionReference> Actions;

    public bool AllAnimationsDone => allAnimationsDone; // Propriété publique pour accéder au booléen

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

            // Position de départ pour l'animation (10 unités au-dessus)
            child.position = spawnPositions[i] + Vector3.up * 10f;

            // Animation avec délai progressif
            child.DOMove(spawnPositions[i], 1f) // Durée de l'animation
                .SetEase(Ease.OutQuart)         // Effet d'animation
                .SetDelay(i * 0.5f)            // Délai progressif entre chaque enfant
                .OnComplete(() =>              // Callback lorsqu'une animation est terminée
                {
                    animationsCompleted++;
                    if (animationsCompleted == transform.childCount)
                    {
                        allAnimationsDone = true; // Toutes les animations sont terminées
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
