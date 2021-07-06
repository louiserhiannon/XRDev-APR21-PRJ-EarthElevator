using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressureUI : MonoBehaviour
{
    public MoveElevator elevator;
    public TMP_Text pressureText;
    private float pressure;

    
    void Start()
    {
        GetPressureText();
    }

    void Update()
    {
        GetPressureText();
    }

    public void GetPressureText()
    {
        pressure = Mathf.Round(elevator.currentDepth * 1000 / 3 + 1);
        pressureText.text = pressure + " atm";
    }
}
