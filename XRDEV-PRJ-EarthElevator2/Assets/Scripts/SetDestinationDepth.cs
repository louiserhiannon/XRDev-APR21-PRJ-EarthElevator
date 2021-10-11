using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationDepth : MonoBehaviour
{
    public ButtonAnimation animatedButton;
    public MoveElevator destination;
    public float depth;
    public Canvas activeCanvas;

    void Start()
    {
       animatedButton.OnButtonPressed += SetDepth;
       //animatedButton.OnButtonPressed += SetActiveCanvas;
    }

    public void SetDepth()
    {
        destination.destinationDepth = depth;
        destination.activeCanvas = activeCanvas;

    }

    //public void SetActiveCanvas()
    //{
    //    canvasManager.activeCanvas = activeCanvas;
    //}
}
