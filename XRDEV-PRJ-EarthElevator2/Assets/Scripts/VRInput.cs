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
    //public float triggerValue;

    public UnityEvent OnTriggerDown;
    public UnityEvent OnTriggerUp;


    // Start is called before the first frame update
    void Start()
    {
        //triggerAxis = $"{hand}Trigger";
        triggerButton = $"{hand}TriggerButton";
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

        //triggerValue = Input.GetAxis(triggerAxis);
    }
}

[System.Serializable]
public enum Hand
{
    Left,
    Right,
}