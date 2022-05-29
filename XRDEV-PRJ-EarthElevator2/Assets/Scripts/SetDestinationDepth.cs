using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationDepth : MonoBehaviour
{
    public ButtonAnimation animatedButton;
    public MoveElevator destination;
    public float depth;

    void Start()
    {
        animatedButton.OnButtonPressed += SetDepth;
    }

 
    public void SetDepth()
    {
        destination.destinationDepth = depth;

    }

}
