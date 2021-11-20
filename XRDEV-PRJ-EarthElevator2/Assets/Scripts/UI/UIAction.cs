using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAction : MonoBehaviour
{
    public CanvasGroup thisPanelActive;
    public CanvasGroup nextPanelActive;
    
    public AudioSource audioSource;
    public AudioClip selectSound;

    public virtual void ButtonClick()
    {

    }
}
