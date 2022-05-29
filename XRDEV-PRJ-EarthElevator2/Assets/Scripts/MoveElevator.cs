using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MoveElevator : MonoBehaviour
{
    public List<Transform> activePoints;
    public Transform activatedActivePoint;
    public AudioClip elevatorSound;
    private AudioSource source;
    public float elevatorVolume = 0.5f;
    public float destinationDepth;
    public float currentDepth = 0f;
    [SerializeField]
    private List<float> currentDepthShafts = new List<float>();
    public float elevatorMaxSpeed;
    public float speed;
    private float targetSpeed;
    private float decelerationTime = 7f;
    [SerializeField]
    private float acceleration;
    public LeverAngle leverAngle;
    public float leverValue;
    private float endPosUp = -30f;
    private float endPosDown = 120f;
    public Canvas infoUI;
    public Canvas controllerLeftUI;
    public Canvas controllerRightUI;
    public Earthquake earthquake;
    public MoveLevelObjects setParent;
    


    //Earth Structure Variables
    public List<float> transitionDepths;
    


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
            currentDepthShafts.Add(currentDepth - activePoints[i].position.y); 
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

        //Disable informational canvases
        DisablePanels();

        //initialize activatedActivePanel
        activatedActivePoint = activePoints[0];

        //start level coroutines
        earthquake.BeginShake();
    }

    void Update()
    {

        //calculate shaft section depths
        for (int i = 0; i < activePoints.Count; i++)
        {
            currentDepthShafts[i] = currentDepth - activePoints[i].position.y;
        }
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
            elevatorMaxSpeed = 50f;
        }

        //Set target speed
        leverValue = leverAngle.leverValue;
        targetSpeed = leverValue * elevatorMaxSpeed;

    }

    public void MoveElevatorDown()
    {


        //Activate correct shaft sections
        
        for (int i = 0; i < activePoints.Count; i++)
        {
            for (int j = 0; j < transitionDepths.Count; j++)
            {
                if (currentDepthShafts[i] > transitionDepths[j] && currentDepthShafts[i] < transitionDepths[j+1])
                {
                    for (int k = 0; k < layers.Count; k++)
                    {
                        layers[k].shafts[i].SetActive(false);

                    }
                    layers[j + 1].shafts[i].SetActive(true);
                }
            }
        }


        //Set elevator speed (decelerate/accelerate 0-50 km either side of destination)
        speed = targetSpeed; //initialize speed
        if ((destinationDepth - currentDepth < (targetSpeed * decelerationTime /2) && destinationDepth - currentDepth > 1) || (destinationDepth - currentDepth > -(targetSpeed * decelerationTime / 2) && destinationDepth - currentDepth < -1))
        {
            SetDecelerateAccelerate();
        }
        
           
        //play elevator sound when moving
        PlayElevatorSound();

        // move and cycle shaft segments (move parent transform, not segments)

        for (int i = 0; i < activePoints.Count; i++)
        {
            activePoints[i].transform.Translate(0f, speed * Time.deltaTime, 0f);
            if (activePoints[i].transform.position.y >= endPosDown)
            {
                if(activePoints[i] == activatedActivePoint) //Sets parent to reset to ShaftMovement just before segment flips. Potential issue if levels are closer together than total length of shaft (120)
                {
                    setParent.ResetLevelTransform();
                    activatedActivePoint = null;
                }
                activePoints[i].transform.Translate(0f, -150f, 0f); //translate by a distance, not TO a point
            }
        }
        currentDepth += speed * Time.deltaTime;

        //stop sound when elevator stops and Set activePoint tether for next destination
        if (currentDepth > (destinationDepth - 1))
        {
            StopElevatorSound();
            SetActivePoint();
        }       
    }

    public void MoveElevatorUp()
    {
        //Activate correct shaft sections

        for (int i = 0; i < activePoints.Count; i++)
        {
            for (int j = 0; j < transitionDepths.Count; j++)
            {
                if (currentDepthShafts[i] > transitionDepths[j] && currentDepthShafts[i] < transitionDepths[j + 1])
                {
                    for (int k = 0; k < layers.Count; k++)
                    {
                        layers[k].shafts[i].SetActive(false);

                    }
                    layers[j].shafts[i].SetActive(true);
                }
            }
        }

        //set elevator speed

        speed = targetSpeed; //initialize speed
        if ((currentDepth - destinationDepth < (targetSpeed * decelerationTime / 2) && currentDepth - destinationDepth > 1) || (currentDepth - destinationDepth > -(targetSpeed * decelerationTime / 2) && currentDepth - destinationDepth < -1))
        {
            SetDecelerateAccelerate();
        }
        
        //play elevator sound when moving
        PlayElevatorSound();

        // move shaft segments (move parent transform, not segments)

        for (int i = 0; i < activePoints.Count; i++)
        {
            activePoints[i].transform.Translate(0f, -speed * Time.deltaTime, 0f);
            if (activePoints[i].transform.position.y <= endPosUp)
            {
                if (activePoints[i] == activatedActivePoint)
                {
                    setParent.ResetLevelTransform();
                    activatedActivePoint = null;
                }
                activePoints[i].transform.Translate(0f, 150f, 0f);
            }
        }
                
        //update depth
        currentDepth -= speed * Time.deltaTime;

        //stop sound when elevator stops and Set activePoint tether for next destination
        if (currentDepth < (destinationDepth + 1))
        {
            StopElevatorSound();
            SetActivePoint();
        }
    }

    private void SetDecelerateAccelerate()
    {
        acceleration = speed / (destinationDepth - currentDepth);
        speed -= acceleration;
        speed = Mathf.Clamp(speed, 0.1f, targetSpeed);
    }

    public void PlayElevatorSound()
    {
        source.PlayOneShot(elevatorSound, elevatorVolume);
    }

    private void StopElevatorSound()
    {
        source.Stop();
    }

    private void SetActivePoint()
    {
        //Find the activePoint that is in the right place
        for (int i = 0; i < activePoints.Count; i++)
        {
            if (activePoints[i].transform.position.y > -5f && activePoints[i].transform.position.y < 20f)
            {
                activatedActivePoint = activePoints[i];
            }
        }

        //Call MoveLevelObjects.MoveWithShaft to SetParent
        setParent.MoveWithShaft(activatedActivePoint);
    }

    public void DisablePanels()
    {
        foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }

        foreach (CanvasGroup controllerRightPanel in controllerRightUI.GetComponentsInChildren<CanvasGroup>())
        {
            controllerRightPanel.alpha = 0;
            controllerRightPanel.interactable = false;
            controllerRightPanel.blocksRaycasts = false;
        }

        foreach (CanvasGroup controllerLeftPanel in controllerLeftUI.GetComponentsInChildren<CanvasGroup>())
        {
            controllerLeftPanel.alpha = 0;
            controllerLeftPanel.interactable = false;
            controllerLeftPanel.blocksRaycasts = false;
        }

    }

    
}
