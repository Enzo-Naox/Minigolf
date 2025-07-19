using DG.Tweening;
using UnityEngine;

public class DOTweenInitializer : MonoBehaviour
{
    void Awake()
    {
        DOTween.SetTweensCapacity(10000, 100); // Ajustez les valeurs selon vos besoins
    }
}