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

    private float amplitude; // the actual amount it moves at a particular point during the earthquake

    public AudioSource audioSource;
    public AudioClip earthquakeSound;
    
    



    void Start()
    {

        directionOfShake = transform.right;
        initialPosition = transform.position; // store this to avoid floating point error drift
        audioSource.PlayOneShot(earthquakeSound);


    }

        void FixedUpdate()
    {

        amplitude = minAmplitude + ( Mathf.Sin(2 * Mathf.PI * Time.time / amplitudePeriod) + 1) / 2 * (maxAmplitude - minAmplitude);
        transform.position = initialPosition + directionOfShake * Mathf.Sin(2 * Mathf.PI * frequency * Time.time) * amplitude;
        


    }
}
