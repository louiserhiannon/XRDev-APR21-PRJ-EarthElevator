using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class UIAddCollider : MonoBehaviour
{

    private GameObject button;
    private BoxCollider2D colliderUI;
    private RectTransform buttonLocation;
    private RectTransform colliderLocation;
    
    void OnEnable()
    {
        button = GetComponent<GameObject>();
        colliderUI = GetComponent<BoxCollider2D>();
        buttonLocation = GetComponent<RectTransform>();
        

    }

    
}
