using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationDepth : MonoBehaviour
{
    public ButtonAnimation animatedButton;
    public MoveElevator destination;
    public CanvasManager canvasManager;
    public float depth;
    public Canvas activeCanvas;

    void Start()
    {
       animatedButton.OnButtonPressed += SetDepth;
    }

    public void SetDepth()
    {
        destination.destinationDepth = depth;
    }

    public void SetActiveCanvas()
    {
        canvasManager.activeCanvas = activeCanvas;
    }
}
