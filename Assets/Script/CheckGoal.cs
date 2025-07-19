using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckGoal : MonoBehaviour
{
    public int currentScene = 0;
    private int NextScene = 0;
    public TMP_Text TxtLevel;
    public GameObject Goal;
    private bool isGoal = false;
    public AudioSource winAudio;

    private void Awake()
    {
        TxtLevel.text = "" + currentScene;
        Goal.gameObject.SetActive(isGoal);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGoal) // V�rifie si le but n'a pas d�j� �t� atteint
        {
            winAudio.Play();
            isGoal = true;
            Goal.gameObject.SetActive(isGoal);
            NextScene = currentScene + 1;
            StartCoroutine(LoadNextSceneWithDelay(2.5f)); // D�marre la coroutine avec un d�lai de 5 secondes
        }
    }

    private IEnumerator LoadNextSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Attend le d�lai sp�cifi�
        string nameScene = $"Level_{NextScene}";
        SceneManager.LoadScene(nameScene); // Charge la sc�ne suivante
    }
}
