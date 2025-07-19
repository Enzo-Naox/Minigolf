using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelsSelections : MonoBehaviour
{
    public void AllerAuLevel(GameObject bouton)
    {
        // R�cup�rer le composant Text attach� au bouton
        TMP_Text buttonText = bouton.GetComponentInChildren<TMP_Text>();

        if (buttonText != null)
        {
            string nameScene = $"Level_{buttonText.text}"; // R�cup�rer le texte du bouton
            SceneManager.LoadScene(nameScene);
            Time.timeScale = 1;
        }
    }
}
