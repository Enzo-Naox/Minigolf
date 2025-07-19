using UnityEngine;
using TMPro; // Nécessaire pour TextMeshPro

public class WaveTextAnimator : MonoBehaviour
{
    public TMP_Text textComponent; // Composant TextMeshPro
    public float waveSpeed = 2f; // Vitesse de l'onde
    public float waveHeight = 10f; // Hauteur maximale de l'onde

    private void Start()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TMP_Text>();
        }

        if (textComponent == null)
        {
            Debug.LogError("Aucun composant TMP_Text trouvé ou assigné.");
            enabled = false;
        }
    }

    private void Update()
    {
        AnimateWave();
    }

    private void AnimateWave()
    {
        textComponent.ForceMeshUpdate(); // Actualise le maillage du texte
        var textInfo = textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            var vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++) // Boucle sur les 4 sommets d'une lettre
            {
                var charMidBaseline = (vertices[textInfo.characterInfo[i].vertexIndex + 0] +
                                       vertices[textInfo.characterInfo[i].vertexIndex + 2]) / 2;

                float waveOffset = Mathf.Sin(Time.time * waveSpeed + charMidBaseline.x * 0.1f) * waveHeight;

                vertices[textInfo.characterInfo[i].vertexIndex + j] += Vector3.up * waveOffset;
            }
        }

        // Applique les modifications au maillage
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
        }
    }
}
