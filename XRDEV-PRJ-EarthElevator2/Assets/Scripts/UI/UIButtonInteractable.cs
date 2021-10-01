using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UIButtonInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private float hoverStartAnimationDuration = 0.2f;
    private float hoverEndAnimationDuration = 0.1f;
    private float scaleIconSize = 1.10f;
    private Vector3 startScale;

    private Canvas thisCanvas;
    public Canvas nextCanvas;
    //private Image icon;
    private Image textBack;
    private TMP_Text text;

    public Color startTextAlpha;
    public Color hoverTextAlpha;
    public Color startTextBackAlpha;
    public Color hoverTextBackAlpha;

    public UnityEvent OnClick;

    private void OnEnable()
    {
        //icon = GetComponent<Image>();
        textBack = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TMP_Text>();
        thisCanvas = GetComponent<Canvas>();
        startScale = transform.localScale;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // hover animations
        transform.DOScale(scaleIconSize, hoverStartAnimationDuration);
        text.DOColor(hoverTextAlpha, hoverStartAnimationDuration);
        textBack.DOColor(hoverTextBackAlpha, hoverStartAnimationDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // exit hover animations
        transform.DOScale(startScale, hoverEndAnimationDuration);
        text.DOColor(startTextAlpha, hoverEndAnimationDuration);
        textBack.DOColor(startTextBackAlpha, hoverEndAnimationDuration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // need to add check to see if there is a next canvas; if not, just disable canvas
        thisCanvas.enabled = false;
        nextCanvas.enabled = true;
    }

   

}    
