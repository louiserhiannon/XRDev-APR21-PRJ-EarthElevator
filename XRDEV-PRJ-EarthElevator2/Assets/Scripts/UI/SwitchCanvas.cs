using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    private Canvas thisCanvas;


    public void OnEnable()
    {
        thisCanvas = GetComponent<Canvas>();
    }

    public void CanvasLoadDestroy(Canvas nextCanvas)
    {
        // need to add check to see if there is a next canvas; if not, just disable canvas
        thisCanvas.enabled = false;
        nextCanvas.enabled = true;
    }
    
}
