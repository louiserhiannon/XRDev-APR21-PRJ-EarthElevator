using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINavigation : MonoBehaviour
{
    private VRInput controller;
    public CanvasGroup thisPanelActive;
    public CanvasGroup nextPanelActive;

    public AudioSource audioSource;
    public AudioClip selectSound;

    public void OnEnable()
    {
        controller = GetComponent<VRInput>();
        controller.OnAButtonDown.AddListener(PanelSwitch);
    }

    public void PanelSwitch()
    {
        if (thisPanelActive != null && nextPanelActive != null)
        {
            thisPanelActive.alpha = 0;
            thisPanelActive.interactable = false;
            thisPanelActive.blocksRaycasts = false;

            nextPanelActive.alpha = 1;
            nextPanelActive.interactable = true;
            nextPanelActive.blocksRaycasts = true;

            //Play Select Sound
            SoundManager.instance.PlaySound(selectSound, audioSource);

            //clear active panels from component
            thisPanelActive = null;
            nextPanelActive = null;
        }
        

        
    }

}
