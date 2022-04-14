using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReference : MonoBehaviour
{
    private VRInput controller;
    public CanvasGroup activePanel;

    public void OnEnable()
    {
        controller = GetComponent<VRInput>();
        controller.OnAButton.AddListener(OpenUIReference);
        controller.OnAButtonUp.AddListener(CloseUIReference);
    }

    public void OnDisable()
    {
        controller.OnAButton.RemoveListener(OpenUIReference);
        controller.OnAButtonUp.RemoveListener(CloseUIReference);
    }

    public void OpenUIReference()
    {
        if (activePanel != null)
        {
            activePanel.alpha = 1;
            activePanel.interactable = true;
            activePanel.blocksRaycasts = true;   
                       
        }
    }

    public void CloseUIReference()
    {
        if (activePanel != null)
        {
            activePanel.alpha = 0;
            activePanel.interactable = false;
            activePanel.blocksRaycasts = false;

        }
    }
}
