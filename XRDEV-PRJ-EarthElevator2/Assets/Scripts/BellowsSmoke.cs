using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellowsSmoke : MonoBehaviour
{
    public LeverAngle leverAngle;
    private ParticleSystem smoke;
    private float newLeverValue;
    private float lastLeverValue;

    void Awake()
    {
        smoke = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        lastLeverValue = 0f;
    }

    void Update()
    {
        newLeverValue = leverAngle.leverValue;
        if (newLeverValue < lastLeverValue - 0.05)
        {
            smoke.Play();
        }
        lastLeverValue = newLeverValue;
    }
}
