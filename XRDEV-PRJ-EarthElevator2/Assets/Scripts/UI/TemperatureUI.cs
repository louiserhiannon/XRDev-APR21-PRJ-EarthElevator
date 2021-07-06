using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TemperatureUI : MonoBehaviour
{
    public MoveElevator elevator;
    public TMP_Text tempText;
    public float temperature;
    public List<float> depths;
    public List<float> temps;



    void Start()
    {
        GetTemperatureText();
    }

    // Update is called once per frame
    void Update()
    {
        GetTemperatureText();
    }
    public void GetTemperatureText()
    {
        for(int i = 0; i < depths.Count; i++)
        {
            if (elevator.currentDepth > depths[i] && elevator.currentDepth <= depths[i + 1])
            {
                temperature = Mathf.Round(temps[i] + (elevator.currentDepth - depths[i]) / (depths[i + 1] - depths[i]) * (temps[i + 1] - temps [i]));
            }
        }

        tempText.text = temperature + " C";
       
    }
}
