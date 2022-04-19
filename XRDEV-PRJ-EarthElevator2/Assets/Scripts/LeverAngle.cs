using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAngle : MonoBehaviour
{
    [SerializeField]
    private float adjustedLeverAngle;
    [SerializeField]
    private float rawLeverAngle;
    public float leverValue;
    private HingeJoint lever;
    
    void Start()
    {
        lever = GetComponent<HingeJoint>();
    }

    void Update()
    {
        rawLeverAngle = lever.angle;
        adjustedLeverAngle = rawLeverAngle - lever.limits.min;
        leverValue = adjustedLeverAngle / (lever.limits.max - lever.limits.min);
    }
}
