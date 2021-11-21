using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetReferenceUI : MonoBehaviour
{
    public ButtonAnimation animatedButton;
    public UIReference reference;
    public Canvas controllerLeftUI;
    public CanvasGroup activePanel;

    void Start()
    {
        animatedButton.OnButtonPressed += SetUI;

    }
    public void SetUI()
    {
       foreach (CanvasGroup panel in controllerLeftUI.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }

        reference.activePanel = activePanel;
    }
}
