using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlagMove : MonoBehaviour
{
    private float moveDistance = 0.5f;  // Distance verticale du mouvement
    private float moveDuration = 1f;
    public GolfSpawn golfSpawn;
    void Update()
    {
        StartBouncing();
    }
    void StartBouncing()
    {
        if (golfSpawn != null && golfSpawn.AllAnimationsDone)
        {
            Vector3 startPosition = transform.position;

            // Animation vers le haut
            transform.DOMoveY(startPosition.y + moveDistance, moveDuration)
                .SetEase(Ease.InOutSine) // Douce montée et descente
                .SetLoops(-1, LoopType.Yoyo); // Animation infinie en boucle (Yoyo)

        }
    }
}
