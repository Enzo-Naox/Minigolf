using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundKeepEnableInput : MonoBehaviour
{
    private keepEnableInput keepEnableInput;

    public void foundkeepEnableInput()
    {
        GameObject foundkeepEnableInput = GameObject.FindGameObjectWithTag("keepEnableInput");
        keepEnableInput = foundkeepEnableInput.GetComponent<keepEnableInput>();
    }

    public keepEnableInput GetKeepEnableInput()
    {
        return keepEnableInput;
    }

    public void setKeepEnableInput()
    {
        foundkeepEnableInput();
    }
}
