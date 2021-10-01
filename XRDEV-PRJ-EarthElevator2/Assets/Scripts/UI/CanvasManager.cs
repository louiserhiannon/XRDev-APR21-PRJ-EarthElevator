using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas activeCanvas;
    public GameObject infoUI;


    public void DisableCanvases()
    {
        foreach (Canvas canvas in infoUI.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = false;
        }


    }

    public void DisplayCanvas()
    {
        //Activate Correct Canvas

        activeCanvas.enabled = true;

    }
}
