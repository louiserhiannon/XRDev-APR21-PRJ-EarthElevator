using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UINavigation : MonoBehaviour
{
    private VRInput controller;
    public CanvasGroup thisPanelActive;
    public CanvasGroup nextPanelActive;
    public GameObject thisButtonActive;


    public AudioSource audioSource;
    public AudioClip selectSound;

    public float pauseBeforeCrack = 1.5f;
    public GameObject groundCrackPrefab;
    public Transform groundCrackPosition;
    private Vector3 startScaleCrack;
    public AudioClip earthquakeSound;
    private Vector3 EndScaleCrack;
    public float crackGrowthDuration = 3f;

    public void OnEnable()
    {
        controller = GetComponent<VRInput>();
        controller.OnAButtonDown.AddListener(UIAction);
    }

    public void UIAction()
    {

        if (thisPanelActive != null && nextPanelActive != null)
        {
            thisPanelActive.alpha = 0;
            thisPanelActive.interactable = false;
            thisPanelActive.blocksRaycasts = false;

            //Play Select Sound
            audioSource.PlayOneShot(selectSound);
            Debug.Log("Select sounds should be playing");

            nextPanelActive.alpha = 1;
            nextPanelActive.interactable = true;
            nextPanelActive.blocksRaycasts = true;


            if (thisButtonActive.tag == "MagmaCrack")
            {
                Debug.Log("MagmaCrack button pressed");
                StartCoroutine(GroundCrack());
            }

            //clear active panels from component
            thisPanelActive = null;
            nextPanelActive = null;
            thisButtonActive = null;
               

        }
        

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

