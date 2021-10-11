using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UIButtonInteractable : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler //, IPointerDownHandler
{
    //private VRInput controller;
    //private Collider buttonCollider;
    //public CanvasManager canvasManager;
    

    private float hoverStartAnimationDuration = 0.2f;
    private float hoverEndAnimationDuration = 0.1f;
    private float scaleIconSize = 1.25f;
    private Vector3 startScale;

    private string AButton;


    //private Image icon;
    public Canvas thisCanvas;
    public Canvas nextCanvas;

    public GameObject infoUI;
    public Image icon;
    public Image textBack;
    public TMP_Text text;

    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip selectSound;


    //public UnityEvent OnAButtonDown;

    private void OnEnable()
    {
        //icon = GetComponent<Image>();
        //textBack = GetComponentInChildren<Image>();
        //text = GetComponentInChildren<TMP_Text>();

        //buttonCollider = GetComponent<Collider>();
        //buttonCollider.isTrigger = true;

        //thisCanvas = GetComponentInParent<Canvas>();
        AButton = "RightAButton";
        startScale = transform.localScale;

        icon.enabled = true;    

        if (textBack != null)
        {
            textBack.enabled = false;
            text.enabled = false;
        }

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // hover animations
        transform.DOScale(scaleIconSize, hoverStartAnimationDuration);

        if (textBack != null)
        {
            textBack.enabled = true;
            text.enabled = true;
        }

        // hover sounds
        SoundManager.instance.PlaySound(hoverSound, audioSource);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // exit hover animations
        transform.DOScale(startScale, hoverEndAnimationDuration);
        if (textBack != null)
        {
            textBack.enabled = false;
            text.enabled = false;
        }

    }

    public void Update()
    {
        if (Input.GetButtonDown(AButton))
        {
            //UISystemProfilerApi.AddMarker("Button.onAButtonDown", this);

            //OnAButtonDown?.Invoke();

            foreach (Canvas canvas in infoUI.GetComponentsInChildren<Canvas>())
            {
                canvas.enabled = false;
                Debug.Log("Canvas should have disappeared");
            }
            
            nextCanvas.enabled = true;

            //Play Select Sound
            SoundManager.instance.PlaySound(selectSound, audioSource);
        }
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("Pointer has been clicked");
        
    //    UISystemProfilerApi.AddMarker("Button.onAButtonDown", this);

    //    //Select Sound
    //    SoundManager.instance.PlaySound(selectSound, audioSource);

    //    OnAButtonDown?.Invoke();

    //}



}    
