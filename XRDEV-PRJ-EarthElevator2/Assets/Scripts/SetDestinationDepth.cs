using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestinationDepth : MonoBehaviour
{
    public ButtonAnimation animatedButton;
    public MoveElevator destination;
    public float depth;
    public GameObject infoUI;
    public Canvas activeCanvas;

    void Start()
    {
        animatedButton.OnButtonPressed += SetDepth;
    }

    public void SetDepth()
    {
        destination.destinationDepth = depth;

        foreach (Canvas canvas in infoUI.GetComponentsInChildren<Canvas>())
        {
            canvas.enabled = false;
        }

        destination.activeCanvas = activeCanvas;
    }

    //public void SetActiveCanva()
    //{
    //    destination.activeCanvas = activeCanvas;
    //}

}
