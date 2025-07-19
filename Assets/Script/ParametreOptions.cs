using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametreOptions : MonoBehaviour
{
    public GameObject parametres;
    public GameObject levels;
    public GameObject masquerMenu;
    void Start()
    {
        parametres.SetActive(false);
        levels.SetActive(false);
    }

    // Update is called once per frame
    public void ParametreActive()
    {
        parametres.SetActive(true);
        masquerMenu.SetActive(false);
    }

    public void LevelsActive()
    {
        levels.SetActive(true);
        masquerMenu.SetActive(false);
    }

    public void RetourAuMenu()
    {
        parametres.SetActive(false);
        levels.SetActive(false);
        masquerMenu.SetActive(true);
    }

    public void FermerLeJeu()
    {
        Application.Quit();
    }
}
