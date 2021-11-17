using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OverrideMagmaCrack : UINavigation
{
    public float pauseBeforeCrack = 1.5f;
    public GameObject groundCrackPrefab;
    public Transform groundCrackPosition;
    private Vector3 startScaleCrack;
    public AudioClip earthquakeSound;
    private Vector3 EndScaleCrack;
    public float crackGrowthDuration = 3f;



    public override void UIAction()
    {
        if (thisPanelActive != null)
        {
            thisPanelActive.alpha = 0;
            thisPanelActive.interactable = false;
            thisPanelActive.blocksRaycasts = false;

            //Play Select Sound
            SoundManager.instance.PlaySound(selectSound, audioSource);

            //clear active panels from component
            thisPanelActive = null;
            nextPanelActive = null;
        }

        StartCoroutine(GroundCrack());
    }

    private IEnumerator GroundCrack()
    {
        yield return new WaitForSeconds(pauseBeforeCrack);

        GameObject groundCrack = Instantiate(groundCrackPrefab, groundCrackPosition);
        groundCrack.transform.localScale = startScaleCrack;
        audioSource.PlayOneShot(earthquakeSound);
        groundCrack.transform.DOScale(EndScaleCrack, crackGrowthDuration);

        yield return new WaitForSeconds(crackGrowthDuration);

        audioSource.Stop();
    }
}
