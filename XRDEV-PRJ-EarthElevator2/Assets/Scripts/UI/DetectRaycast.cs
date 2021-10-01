using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DetectRaycast : MonoBehaviour
{
    public VRInput controller;

    private GraphicRaycaster raycaster;
    private PointerEventData eventData;
    private EventSystem eventSystem;

  


    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();

        //Add listener
    }

    void Update()
    {
        //Check if line is being cast (i.e. grip button is pressed)
    
    }
}
