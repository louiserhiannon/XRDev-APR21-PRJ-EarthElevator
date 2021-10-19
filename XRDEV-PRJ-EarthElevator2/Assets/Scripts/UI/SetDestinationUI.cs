using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDestinationUI : MonoBehaviour
{
    public ButtonAnimation animatedButton;
    public MoveElevator destination;
    public Canvas infoUI;
    public GameObject activePanel;

    void Start()
    {
        animatedButton.OnButtonPressed += SetUI;
    }

    public void SetUI()
    {
        foreach (Image image in infoUI.GetComponentsInChildren<Image>())
        {
            image.enabled = false;
        }

        foreach (Button button in infoUI.GetComponentsInChildren<Button>())
        {
            button.enabled = false;
        }

        destination.activePanel = activePanel;
    }

    //public void SetActiveCanva()
    //{
    //    destination.activeCanvas = activeCanvas;
    //}

}
