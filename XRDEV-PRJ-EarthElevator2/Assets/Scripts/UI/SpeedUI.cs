using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUI : MonoBehaviour
{
    public MoveElevator elevator;
    public float speed;
    public TMP_Text speedText;

    void Start()
    {
        GetSpeed();
    }

    void Update()
    {
        GetSpeed();
    }

    public void GetSpeed()
    {
        speed = Mathf.Round(elevator.speed);
        speedText.text = speed + " km/s";
    }
}
