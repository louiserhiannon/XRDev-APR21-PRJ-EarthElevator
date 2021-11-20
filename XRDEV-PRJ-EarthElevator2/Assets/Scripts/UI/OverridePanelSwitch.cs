using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverridePanelSwitch : UIAction
{
      
    public override void ButtonClick()
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
