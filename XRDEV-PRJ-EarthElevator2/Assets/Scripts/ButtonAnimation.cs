using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public delegate void ButtonPressedEvent();
    public ButtonPressedEvent OnButtonPressed;

    private Animator buttonAnim;


    void Awake()
    {
        buttonAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnim.SetTrigger("Pressed");
            OnButtonPressed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnim.SetTrigger("Released");
        }
    }
}
