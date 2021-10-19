using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UINavButtonInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float hoverStartAnimationDuration = 0.2f;
    private float hoverEndAnimationDuration = 0.1f;
    private float scaleIconSize = 1.25f;
    private Vector3 startScale;

    private string AButton;

    public Canvas infoUI;
    //public Canvas nextCanvas;

    public GameObject nextPanel;
    public Image button;
       

    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip selectSound;


    public UnityEvent OnAButtonDown;

    private void OnEnable()
    {

        AButton = "RightAButton";
        startScale = transform.localScale;

        button.enabled = true;

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // hover animations
        transform.DOScale(scaleIconSize, hoverStartAnimationDuration);


        // hover sounds
        SoundManager.instance.PlaySound(hoverSound, audioSource);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // kill all animations first
        transform.DOKill();

        // exit hover animations
        transform.DOScale(startScale, hoverEndAnimationDuration);

    }

    public void Update()
    {
        if (Input.GetButtonDown(AButton))
        {
            //UISystemProfilerApi.AddMarker("Button.onAButtonDown", this);

            //OnAButtonDown?.Invoke();

            //Disable all UI elements

            foreach (Button button in infoUI.GetComponentsInChildren<Button>())
            {
                button.enabled = false;
                Debug.Log("All buttons should have disappeared");
            }

            foreach (Image image in infoUI.GetComponentsInChildren<Image>())
            {
                image.enabled = false;
                Debug.Log("All images should have disappeared");
            }

            //enable required UI elements

            foreach (Button button in nextPanel.GetComponentsInChildren<Button>())
            {
                button.enabled = true;
                Debug.Log("Active panel buttons should have appeared");
            }

            foreach (Image image in nextPanel.GetComponentsInChildren<Image>())
            {
                image.enabled = true;
                Debug.Log("Active panel buttons should have appeared");
            }

            //Play Select Sound
            SoundManager.instance.PlaySound(selectSound, audioSource);
        }
    }
}