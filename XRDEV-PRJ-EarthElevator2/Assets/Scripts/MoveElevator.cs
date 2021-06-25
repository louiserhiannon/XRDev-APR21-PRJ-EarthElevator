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
    //private List<float> currentShaftDepths;
    private float startPosUp = 35f;
    private float startPosDown = -4f;
    private float endPosUp = -4f;
    private float endPosDown = 35f;

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

        //Update speed
        leverValue = leverAngle.leverValue;
        Debug.Log($"The lever value is {leverValue}");
        speed = leverValue * elevatorMaxSpeed;
        Debug.Log("Speed has been set");

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

        //if (currentDepth > (graniteGneissTransition - speed / 100) && currentDepth < (graniteGneissTransition + speed / 100))
        //{
        //    for (int i = 0; i < activePoints.Count; i++) //should change to shafts, but it doesn't like that for some reason...
        //    {
        //        layers[0].shafts[i].SetActive(false); //de-activate granite (layer 0)
        //        layers[1].shafts[i].SetActive(true); //activate gneiss (layer 1)
        //    }
        //}

        //if (currentDepth > (gneissLithosphereTransition - speed / 100) && currentDepth < (gneissLithosphereTransition + speed / 100))
        //{
        //    for (int i = 0; i < activePoints.Count; i++) //should change to shafts, but it doesn't like that for some reason...
        //    {
        //        layers[1].shafts[i].SetActive(false); //de-activate gneiss (layer 1)
        //        layers[2].shafts[i].SetActive(true); //activate lithosphere (layer 2)
        //    }
        //}

        //if (currentDepth > (mantleCoreTransition - speed / 100) && currentDepth < (mantleCoreTransition + speed / 100))
        //{
        //    for (int i = 0; i < activePoints.Count; i++) //should change to shafts, but it doesn't like that for some reason...
        //    {
        //        layers[2].shafts[i].SetActive(false); //de-activate lithosphere (layer 2)
        //        layers[3].shafts[i].SetActive(true); //activate outer core (layer 3)
        //    }
        //}

        // move and cycle shaft segments (move parent transform, not segments)
        for (int i = 0; i < activePoints.Count; i++)
        {
            activePoints[i].transform.Translate(0f, speed * Time.deltaTime, 0f);
            if (activePoints[i].transform.position.y >= endPosDown)
            {
                activePoints[i].transform.position = new Vector3(activePoints[i].transform.position.x, startPosDown, activePoints[i].transform.position.z);
            }
        }

        //update depth
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

        //if (currentDepth > (graniteGneissTransition - speed / 100) && currentDepth < (graniteGneissTransition + speed / 100))
        //{
        //    for(int i = 0; i < activePoints.Count; i++) //should change to shafts, but it doesn't like that for some reason...
        //    {
        //        layers[1].shafts[i].SetActive(false); //de-activate gneiss (layer 1)
        //        layers[0].shafts[i].SetActive(true); //activate granite (layer 0)
        //    }
        //}


        //if (currentDepth > (gneissLithosphereTransition - speed / 100) && currentDepth < (gneissLithosphereTransition + speed / 100))
        //{
        //    for (int i = 0; i < activePoints.Count; i++) //should change to shafts, but it doesn't like that for some reason...
        //    {
        //        layers[2].shafts[i].SetActive(false); //de-activate lithosphere (layer 2)
        //        layers[1].shafts[i].SetActive(true); //activate gneiss (layer 1)
        //    }
        //}

        //if (currentDepth > (mantleCoreTransition - speed / 100) && currentDepth < (mantleCoreTransition + speed / 100))
        //{
        //    for (int i = 0; i < activePoints.Count; i++) //should change to shafts, but it doesn't like that for some reason...
        //    {
        //        layers[3].shafts[i].SetActive(false); //de-activate outer core (layer 3)
        //        layers[2].shafts[i].SetActive(true); //activate lithosphere (layer 2)
        //    }
        //}

        // move and cycle shaft segment (cycle parents not shafts)
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
