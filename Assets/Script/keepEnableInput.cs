using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class keepEnableInput : MonoBehaviour
{
    private bool ControleInput = false;
    public static keepEnableInput Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool getControleInput()
    {
        return ControleInput;
    }

    public void setControleInput(bool _ControleInput)
    {
        ControleInput = _ControleInput;
    }
}
