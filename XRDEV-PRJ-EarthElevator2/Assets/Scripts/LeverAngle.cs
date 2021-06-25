using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAngle : MonoBehaviour
{
    public float leverValue;
    public float adjustedLeverAngle;
    private HingeJoint lever;
    
    void Start()
    {
        lever = GetComponent<HingeJoint>();
    }

    void Update()
    {
        adjustedLeverAngle = lever.angle - lever.limits.min;
        leverValue = adjustedLeverAngle / (lever.limits.max - lever.limits.min);
    }
}
