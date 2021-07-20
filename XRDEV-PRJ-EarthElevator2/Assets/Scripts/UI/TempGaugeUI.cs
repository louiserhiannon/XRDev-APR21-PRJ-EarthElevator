using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempGaugeUI : MonoBehaviour
{
    public MoveElevator elevator;
    public Transform tempPointer;
    private float minTempAngle = 180f;
    private float maxTempAngle = 0f;
    private float minTemp = 0f;
    private float maxTemp = 5000f;
    private float pointerAngleRange;
    private float tempPointerAngle;
    public float temperature;
    public List<float> depths;
    public List<float> temps;

    
    void Start()
    {
        tempPointer = GetComponent<Transform>();
        tempPointer.eulerAngles = new Vector3(0, 0, minTempAngle);
    }

    
    void Update()
    {
        GetTemperature();
        UpdateTempGauge();
    }

    
    private void GetTemperature()
    {
        for (int i = 0; i < depths.Count; i++)
        {
            if (elevator.currentDepth > depths[i] && elevator.currentDepth <= depths[i + 1])
            {
                temperature = temps[i] + (elevator.currentDepth - depths[i]) / (depths[i + 1] - depths[i]) * (temps[i + 1] - temps[i]);
            }
        }
    }

    private void UpdateTempGauge()
    {
        pointerAngleRange = minTempAngle - maxTempAngle;
        tempPointerAngle = minTempAngle - temperature / (maxTemp - minTemp) * pointerAngleRange;
        tempPointer.eulerAngles = new Vector3(0, 0, tempPointerAngle);

    }
}
