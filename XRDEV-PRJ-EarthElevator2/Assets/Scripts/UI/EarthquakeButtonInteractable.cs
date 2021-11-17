using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using System;

public class EarthquakeButtonInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private float hoverStartAnimationDuration = 0.2f;
    private float hoverEndAnimationDuration = 0.1f;
    private float scaleIconSize = 1.25f;
    public float pauseBeforeCrack = 1.5f;
    public float crackGrowthDuration = 3f;
    private Vector3 startScaleButton;
    private Vector3 startScaleCrack;
    private Vector3 EndScaleCrack;
    public Transform groundCrackPosition;

    

    public Canvas infoUI;
    public Image icon;
    public CanvasGroup earthquakePanel;

    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip earthquakeSound;

    public GameObject groundCrackPrefab;

    //public UINavigation nav;
    //public CanvasGroup thisPanel;
    //public CanvasGroup nextPanel;

    private void OnEnable()
    {
        startScaleButton = transform.localScale;
        startScaleCrack = new Vector3(0f, 0f, 1f);
        EndScaleCrack = new Vector3(0.76f, 1f, 1f);
             
        icon.enabled = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // hover animations
        transform.DOScale(scaleIconSize, hoverStartAnimationDuration);


        // hover sounds
        SoundManager.instance.PlaySound(hoverSound, audioSource);

        //make button 'selectable' by assigning active panels to UINavigation (controller)
        //nav.thisPanelActive = thisPanel;
        //nav.nextPanelActive = nextPanel;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // exit hover animations
        transform.DOScale(startScaleButton, hoverEndAnimationDuration);

        ////make button 'unselectable' by removing active panels to UINavigation (controller)
        //nav.thisPanelActive = null;
        //nav.nextPanelActive = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DeActivateEarthquakePanel();
        StartCoroutine(GroundCrack());
    }

    private void DeActivateEarthquakePanel()
    {
        earthquakePanel.alpha = 0;
        earthquakePanel.interactable = false;
        earthquakePanel.blocksRaycasts = false;
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
