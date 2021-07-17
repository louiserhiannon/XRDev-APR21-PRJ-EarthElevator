using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepthUI : MonoBehaviour
{
    public MoveElevator elevator;
    private float depth;
    public TMP_Text depthText;
    void Start()
    {
        GetDepthText();
    }

    
    void Update()
    {
        GetDepthText();
    }

    public void GetDepthText()
    {
        depth = Mathf.Round(elevator.currentDepth);
        depthText.text = depth.ToString();
    }
}
