using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UINavButtonInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float hoverStartAnimationDuration = 0.2f;
    private float hoverEndAnimationDuration = 0.1f;
    private float scaleIconSize = 1.25f;
    private Vector3 startScale;

    public Canvas infoUI;
    public Image icon;

    public AudioSource audioSource;
    public AudioClip hoverSound;

    public UINavigation nav;
    public CanvasGroup thisPanel;
    public CanvasGroup nextPanel;

    private void OnEnable()
    {
        startScale = transform.localScale;
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
        nav.thisPanelActive = thisPanel;
        nav.nextPanelActive = nextPanel;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // exit hover animations
        transform.DOScale(startScale, hoverEndAnimationDuration);

        //make button 'unselectable' by removing active panels to UINavigation (controller)
        nav.thisPanelActive = null;
        nav.nextPanelActive = null;
    }
}
