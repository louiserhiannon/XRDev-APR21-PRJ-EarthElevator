using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElevator : MonoBehaviour
{
    public List<Transform> activePoints;
    public AudioClip elevatorSound;
    private AudioSource source;
    public float elevatorVolume = 0.5f;
    public float destinationDepth;
    public float currentDepth;
    public float elevatorMaxSpeed;
    public float speed;
    public LeverAngle leverAngle;
    public float leverValue;
    private List<float> currentShaftDepths;
    private float startPosUp = 95f;
    private float startPosDown = -105f;
    private float endPosUp = -105f;
    private float endPosDown = 95f;

    //Earth Structure Variables
    public List<float> transitions;
    public float graniteGneissTransition;
    public float gneissLithosphereTransition;
    public float mantleCoreTransition;


    [System.Serializable]
    public class Layer
    {
        public string key;
        public GameObject prefab;
        public List<GameObject> shafts;
        public bool active;
    }

    public List<Layer> layers;
    

    void Start()
    {
        for (int i = 0; i < activePoints.Count; i++)
        {
            for (int j = 0; j < layers.Count; j++)
            {
                GameObject shaft = Instantiate(layers[j].prefab, activePoints[i], false);
                shaft.SetActive(layers[j].active);
                layers[j].shafts.Add(shaft);
            }
        }

        source = GetComponent<AudioSource>();

        //set max speed
        elevatorMaxSpeed = 6f;
    }

    void Update()
    {

       // Determine movement direction based on destination depth and current depth
                // if elevator is 'above' the target depth
        if (destinationDepth > (currentDepth + 1)) // + 1 added to stop it calling MoveElevatorDown() when it's just going to get held up by the next set of if statements
        {
            // move elevator down
            Debug.Log("destination depth more than current depth - should be moving down");
            MoveElevatorDown();
        }

            // if elevator is 'below' the target depth
        if (destinationDepth < (currentDepth - 1)) // - 1 added to stop it calling MoveElevatorUp() when it's just going to get held up by the next set of if statements
        {
            // move elevator up
            Debug.Log("destination depth less than current depth - should be moving up");
            MoveElevatorUp();
        }

        
        //Set elevator max speed
        if (currentDepth < 100f)
        {
            elevatorMaxSpeed = 6f;
        }
        else
        {
            elevatorMaxSpeed = 100f;
        }
        
        //Update speed
        leverValue = leverAngle.leverValue;
        speed = leverValue * elevatorMaxSpeed;

    }

    public void MoveElevatorDown()
    {
              

        //Activate correct shaft sections
        for (int i = 0; i < transitions.Count; i++)
        {
            if (currentDepth > (transitions[i] - speed / 100) && currentDepth < (transitions[i] + speed / 100))
            {
                for (int j = 0; j < activePoints.Count; j++)
                {
                    for (int k = 0; k < layers.Count; k++)
                    {
                        layers[k].shafts[j].SetActive(false);
                    }

                    layers[i+1].shafts[j].SetActive(true);
                }
            }
        }

        //play elevator sound when moving
        PlayElevatorSound();


        // move shaft segments (move parent transform, not segments)

        
        for (int i = 0; i < activePoints.Count; i++)
        {
            activePoints[i].transform.Translate(0f, speed * Time.deltaTime, 0f);
            if (activePoints[i].transform.position.y >= endPosDown)
            {
                activePoints[i].transform.position = new Vector3(activePoints[i].transform.position.x, startPosDown, activePoints[i].transform.position.z); ;
            }

            Debug.Log(activePoints[1].transform.position.y);
        }
        //cycle shaft segments

        currentDepth += speed * Time.deltaTime;

        //stop sound when elevator stops
            if (currentDepth >= (destinationDepth - speed / 10))
        {
            StopElevatorSound();
        }
    }

    public void MoveElevatorUp()
    {
        //Activate correct shaft sections
        for (int i = 0; i < transitions.Count; i++)
        {
            if (currentDepth > (transitions[i] - speed / 100) && currentDepth < (transitions[i] + speed / 100))
            {
                for (int j = 0; j < activePoints.Count; j++)
                {
                    for (int k = 0; k < layers.Count; k++)
                    {
                        layers[k].shafts[j].SetActive(false);
                    }

                    layers[i].shafts[j].SetActive(true);
                }
            }
        }

        //play elevator sound when moving
        PlayElevatorSound();

        // move shaft segments (move parent transform, not segments)

        for (int i = 0; i < activePoints.Count; i++)
        {
            activePoints[i].transform.Translate(0f, -speed * Time.deltaTime, 0f);
            if (activePoints[i].transform.position.y <= endPosUp)
            {
                activePoints[i].transform.position = new Vector3(activePoints[i].transform.position.x, startPosUp, activePoints[i].transform.position.z);
            }
        }

 

        //update depth
        currentDepth -= speed * Time.deltaTime;

        //stop sound when elevator stops
        if (currentDepth < (destinationDepth + speed / 10))
        {
            StopElevatorSound();
        }
    }


    public void PlayElevatorSound()
    {
        source.PlayOneShot(elevatorSound, elevatorVolume);
    }

    private void StopElevatorSound()
    {
        source.Stop();
    }
}
