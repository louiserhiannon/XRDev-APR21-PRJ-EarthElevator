using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINavWelcome : MonoBehaviour
{
    public CanvasGroup thisPanel;
    public CanvasGroup nextPanel;

    
    public void PanelGoodbye()
    {
        thisPanel.alpha = 0;
        thisPanel.interactable = false;
        thisPanel.blocksRaycasts = false;

    }

     public void PanelHello()
    {
        nextPanel.alpha = 0;
        nextPanel.interactable = true;
        nextPanel.blocksRaycasts = true;
    } 
    
}
