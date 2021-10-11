using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSky : MonoBehaviour
{
    public GameObject sky;
    public GameObject blackhole;
    public MoveElevator moveElevator;
    public float speed;


    void Start()
    {

        speed = moveElevator.speed;
    
    }

    void Update()
    {
        if (sky.transform.position.y <= blackhole.transform.position.y)
        {
            sky.transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
    }
}
