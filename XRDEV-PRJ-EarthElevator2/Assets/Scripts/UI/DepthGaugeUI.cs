using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthGaugeUI : MonoBehaviour
{
    public MoveElevator elevator;
    public float depth;
    public float maxDepth = 6300f;
    public RectTransform elevatorMarker;
    public float markerPosY;
    private float markerPosYRange;
    public float markerPosYMax = 0.60f; 
    public float markerPosYMin = -0.633f;
        

    void Start()
    {
        elevatorMarker = GetComponent<RectTransform>();
        elevatorMarker.anchoredPosition = new Vector2(-0.0215f, 0.6f);
      
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateGauge();
    }

    private void UpdateGauge()
    {
        depth = elevator.currentDepth;
        markerPosYRange = markerPosYMax - markerPosYMin;
        markerPosY = markerPosYMax - depth / maxDepth * markerPosYRange;
        elevatorMarker.anchoredPosition = new Vector2(-0.0215f, markerPosY);

    }
}
