using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRInput : MonoBehaviour
{
    // Records all the data from the controllers

    public Hand hand = Hand.Left;

    //private string triggerAxis;
    private string triggerButton;
    private string gripButton;
    private string AButton;
    private string XButton;
    //public float triggerValue;

    public UnityEvent OnTriggerDown;
    public UnityEvent OnTriggerUp;
    public UnityEvent OnGrip;
    public UnityEvent OnGripUp;
    public UnityEvent OnAButtonDown;
    public UnityEvent OnAButton;
    public UnityEvent OnAButtonUp;


    // Start is called before the first frame update
    void Start()
    {
        //triggerAxis = $"{hand}Trigger";
        triggerButton = $"{hand}TriggerButton";
        gripButton = $"{hand}GripButton";
        AButton = $"{hand}AButton";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(triggerButton))
        {
            OnTriggerDown?.Invoke();
        }

        if (Input.GetButtonUp(triggerButton))
        {
            OnTriggerUp?.Invoke();
        }

        if (Input.GetButton(gripButton))
        {
            OnGrip?.Invoke();
        }

        if (Input.GetButtonUp(gripButton))
        {
            OnGripUp?.Invoke();
        }

        if (Input.GetButtonDown(AButton))
        {
            OnAButtonDown?.Invoke();
        }

        if (Input.GetButton(AButton))
        {
            OnAButton?.Invoke();
        }

        if (Input.GetButtonUp(AButton))
        {
            OnAButtonUp?.Invoke();
        }

        //triggerValue = Input.GetAxis(triggerAxis);
    }
}

[System.Serializable]
public enum Hand
{
    Left,
    Right,
}