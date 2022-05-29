using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    public LeverAngle leverAngle;
    private ParticleSystem water;
    public float flowTime;

    void Awake()
    {
        water = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        flowTime = 0f;
    }

    void Update()
    {
        if(leverAngle.leverValue <= -0.4f)
        {
            water.Play();
            flowTime += Time.deltaTime;
        }
        else
        {
            water.Stop();
        }
    }
}
