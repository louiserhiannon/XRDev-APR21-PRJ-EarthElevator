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
    public float shakeDuration = 5f;
    public float pauseAfterShake = 1f;
    private float timePassed;

    private float amplitude; // the actual amount it moves at a particular point during the earthquake

    public AudioSource audioSource;
    public AudioClip earthquakeSound;

    public Canvas infoUI;
    public CanvasGroup earthquakePanel;
    
    

    void Start()
    {

        foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }

        directionOfShake = transform.right;
        initialPosition = transform.position; // store this to avoid floating point error drift

        
        StartCoroutine(GroundShake());

        
        

    }

    private IEnumerator GroundShake()
    {
        yield return new WaitForSeconds(pauseBeforeShake);

        timePassed = 0f;
        audioSource.PlayOneShot(earthquakeSound);

        while (timePassed < shakeDuration)
        {
            amplitude = minAmplitude + (Mathf.Sin(2 * Mathf.PI * Time.time / amplitudePeriod) + 1) / 2 * (maxAmplitude - minAmplitude);
            transform.position = initialPosition + directionOfShake * Mathf.Sin(2 * Mathf.PI * frequency * Time.time) * amplitude;

            timePassed += Time.deltaTime;
            yield return null;
        }

        StopGroundShake();

        yield return new WaitForSeconds(pauseAfterShake);

        ActivateEarthquakePanel();

    }

    

    private void StopGroundShake()
    {
        audioSource.Stop();
    }

    private void ActivateEarthquakePanel()
    {
        earthquakePanel.alpha = 1;
        earthquakePanel.interactable = true;
        earthquakePanel.blocksRaycasts = true; ;
    }

    //    void FixedUpdate()
    //{

    //    amplitude = minAmplitude + (Mathf.Sin(2 * Mathf.PI * Time.time / amplitudePeriod) + 1) / 2 * (maxAmplitude - minAmplitude);
    //    transform.position = initialPosition + directionOfShake * Mathf.Sin(2 * Mathf.PI * frequency * Time.time) * amplitude;

    //}
}
