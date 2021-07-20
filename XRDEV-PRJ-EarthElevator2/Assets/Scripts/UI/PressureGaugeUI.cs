using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGaugeUI : MonoBehaviour
{
    public MoveElevator elevator;
    public Transform pressurePointer;
    private float minPressureAngle = 180f;
    private float maxPressureAngle = 0f;
    private float minPressure = 0f;
    private float maxPressure = 4000000f;
    private float pointerAngleRange;
    private float pressurePointerAngle;
    public float pressure;
    public List<float> depths;
    public List<float> pressures;

    void Start()
    {
        pressurePointer = GetComponent<Transform>();
        pressurePointer.eulerAngles = new Vector3(0, 0, minPressureAngle);
    }

    
    void Update()
    {
        GetPressure();
        UpdatePressureGauge();
    }

    private void GetPressure()
    {
        for (int i = 0; i < depths.Count; i++)
        {
            if (elevator.currentDepth > depths[i] && elevator.currentDepth <= depths[i + 1])
            {
                pressure = pressures[i] + (elevator.currentDepth - depths[i]) / (depths[i + 1] - depths[i]) * (pressures[i + 1] - pressures[i]);
            }
        }
    }

    private void UpdatePressureGauge()
    {
        pointerAngleRange = minPressureAngle - maxPressureAngle;
        pressurePointerAngle = minPressureAngle - pressure / (maxPressure - minPressure) * pointerAngleRange;
        pressurePointer.eulerAngles = new Vector3(0, 0, pressurePointerAngle);

    }

}
