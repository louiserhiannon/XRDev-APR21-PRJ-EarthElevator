using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LocationText : MonoBehaviour
{
    public MoveElevator elevator;
    private float depth;
    public TMP_Text locationText;

    void Start()
    {
        GetLocationText();
    }

    void Update()
    {
        GetLocationText();
    }

    public void GetLocationText()
    {
        depth = elevator.currentDepth;
        if (depth <= 50f)
        {
            locationText.text = "Crust";
        }

        if(depth > 50f && depth <= 2900f)
        {
            locationText.text = "Mantle";
        }

        if (depth > 2900f && depth <= 5100f)
        {
            locationText.text = "Outer Core";
        }

        if (depth > 5100f)
        {
            locationText.text = "Inner Core";
        }
    }
}
