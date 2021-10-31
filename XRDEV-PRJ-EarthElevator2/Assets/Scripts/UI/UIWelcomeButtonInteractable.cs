using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UIWelcomeButtonInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float hoverStartAnimationDuration = 0.2f;
    private float hoverEndAnimationDuration = 0.1f;
    private float scaleIconSize = 1.25f;
    private Vector3 startScale;

    public Canvas infoUI;
    public Image icon;
    public Image textBack;
    public TMP_Text text;

    public AudioSource audioSource;
    public AudioClip hoverSound;
    
    public UINavigation nav;
    public CanvasGroup thisPanel;
    public CanvasGroup nextPanel;

    private void OnEnable()
    {

        startScale = transform.localScale;

        icon.enabled = true;
        textBack.enabled = false;
        text.enabled = false; 

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // hover animations
        transform.DOScale(scaleIconSize, hoverStartAnimationDuration);

        textBack.enabled = true;
        text.enabled = true;
        
        // hover sounds
        SoundManager.instance.PlaySound(hoverSound, audioSource);

        //make button 'selectable' by assigning active panels to UINavigation (controller)
        nav.thisPanelActive = thisPanel;
        nav.nextPanelActive = nextPanel;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // exit hover animations
        transform.DOScale(startScale, hoverEndAnimationDuration);
        textBack.enabled = false;
        text.enabled = false;

        //make button 'unselectable' by removing active panels to UINavigation (controller)
        nav.thisPanelActive = null;
        nav.nextPanelActive = null;
    }
}
