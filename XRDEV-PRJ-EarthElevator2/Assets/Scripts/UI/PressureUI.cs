using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressureUI : MonoBehaviour
{
    public MoveElevator elevator;
    public TMP_Text pressureText;
    private float pressure;
    public List<float> depths;
    public List<float> pressures;


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
        for (int i = 0; i < depths.Count; i++)
        {
            if (elevator.currentDepth > depths[i] && elevator.currentDepth <= depths[i + 1])
            {
                pressure = Mathf.Round(pressures[i] + (elevator.currentDepth - depths[i]) / (depths[i + 1] - depths[i]) * (pressures[i + 1] - pressures[i]));
            }
        }

        pressureText.text = pressure.ToString();
    }
}
