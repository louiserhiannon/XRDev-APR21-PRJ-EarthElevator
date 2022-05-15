using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 directionOfShake;

    public float maxAmplitude; // the max amount it moves
    public float minAmplitude; // the min amount it moves
    public float amplitudePeriod; //the period of the amplitude as it changes over the course of the earthquake (in seconds)
    public float frequency; // the frequency of the earthquake (oscilations per second or Hz)
    public float pauseBeforeShake = 3f;
    public float shakeDuration = 15f;
    public float pauseAfterShake = 2f;
    [SerializeField] private float shakeTime;
    
    private float amplitude; // the actual amount it moves at a particular point during the earthquake

    public AudioSource audioSource;
    public AudioClip earthquakeSound;
    //What about using the SoundManager here?

    public Canvas infoUI;
    public CanvasGroup earthquakePanel;
    public MoveElevator moveElevator;
    
    

    void Start()
    {

        directionOfShake = transform.right;
        initialPosition = transform.position; // store this to avoid floating point error drift     
        
    }

    public void BeginShake()
    {
        shakeTime = 0f;     
        StartCoroutine(GroundShake());
    }

    private IEnumerator GroundShake()
    {
       
        while (moveElevator.destinationDepth != 25f || moveElevator.currentDepth < 24f || moveElevator.currentDepth > 26f)
            {
                yield return null;
            }

        yield return new WaitForSeconds(pauseBeforeShake);

        // check to see if it was just moving through
        // Add code that "resets" the coroutine. I think the coroutine needs to be called using the string method to allow this
        // https://forum.unity.com/threads/how-to-cancel-and-restart-a-coroutine.435493/

        //if (moveElevator.currentDepth > 24f || moveElevator.currentDepth < 26f)
        //{
            

        //}

        audioSource.PlayOneShot(earthquakeSound);
        
        while (shakeTime < shakeDuration)
        {
            shakeTime += Time.fixedDeltaTime;
            amplitude = minAmplitude + (Mathf.Sin(2 * Mathf.PI * Time.time / amplitudePeriod) + 1) / 2 * (maxAmplitude - minAmplitude);
            transform.position = initialPosition + directionOfShake * Mathf.Sin(2 * Mathf.PI * frequency * Time.time) * amplitude;

            yield return null;
        }

        audioSource.Stop();

        yield return new WaitForSeconds(pauseAfterShake);

        ActivateEarthquakePanel();

        //Add code here to reset the coroutine, but only once it has left the "level". See above for link
        //while (moveElevator.currentDepth >= 24f || moveElevator.currentDepth <= 26f)
        //{
        //    yield return null;
        //}

        //StartCoroutine(GroundShake());

    }

    

    private void ActivateEarthquakePanel()
    {
        earthquakePanel.alpha = 1;
        earthquakePanel.interactable = true;
        earthquakePanel.blocksRaycasts = true;
    }

    //    void FixedUpdate()
    //{

    //    amplitude = minAmplitude + (Mathf.Sin(2 * Mathf.PI * Time.time / amplitudePeriod) + 1) / 2 * (maxAmplitude - minAmplitude);
    //    transform.position = initialPosition + directionOfShake * Mathf.Sin(2 * Mathf.PI * frequency * Time.time) * amplitude;

    //}
}
