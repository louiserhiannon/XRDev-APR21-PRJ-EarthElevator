using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UIButtonInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float hoverStartAnimationDuration = 0.2f;
    private float hoverEndAnimationDuration = 0.1f;
    private float scaleIconSize = 1.25f;
    private Vector3 startScale;

    public Canvas infoUI;


    public Image icon;
    private Image textBack;
    private TMP_Text text;
    public UIButtonInteractable button;

    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip selectSound;

    private VRInput controller;
    public UnityEvent OnAButtonDown;

    public UINavigation nav;
    public CanvasGroup thisPanel;
    public CanvasGroup nextPanel;

    private void OnEnable()
    {

        startScale = transform.localScale;

        icon.enabled = true;

        if (button.tag == "Welcome")
        {
            textBack = button.GetComponentInChildren<Image>();
            text = button.GetComponentInChildren<TMP_Text>();
            textBack.enabled = false;
            text.enabled = false;
        }


        controller = GetComponent<VRInput>();


    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // hover animations
        transform.DOScale(scaleIconSize, hoverStartAnimationDuration);

        if (button.tag == "Welcome")
        {
            textBack.enabled = true;
            text.enabled = true;
        }

        // hover sounds
        SoundManager.instance.PlaySound(hoverSound, audioSource);

        //controller.OnAButtonDown.AddListener(PanelSwitch);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // exit hover animations
        transform.DOScale(startScale, hoverEndAnimationDuration);
        textBack.enabled = false;
        text.enabled = false;

        //controller.OnAButtonDown.RemoveListener(PanelSwitch);

    }


    public void PanelSwitch()
    {
        //UISystemProfilerApi.AddMarker("Button.onAButtonClick", this);

        //nav.ThisPanel(thisPanel);
        //nav.NextPanel(nextPanel);

        //Play Select Sound
        SoundManager.instance.PlaySound(selectSound, audioSource);

        //Remove listener
        //controller.OnAButtonDown.RemoveListener(PanelSwitch);

    }
}
