using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGrab : MonoBehaviour
{
    private VRInput controller;
    public GrabbableObject hoveredObject;
    public GrabbableObject grabbedObject;

    void Start()
    {
        controller = GetComponent<VRInput>();
        controller.OnTriggerDown.AddListener(GrabLever); // hooks into event identified in VRInput and connects it to GrabLever()
        controller.OnTriggerUp.AddListener(ReleaseLever); // hooks into event identified in VRInput and connects it to ReleaseLever()
    }

    private void OnDisable()
    {
        controller.OnTriggerDown.RemoveListener(GrabLever); //try with OnTrigger if getting the same weird artifacting - seems to be better
        controller.OnTriggerUp.RemoveListener(GrabLever);
    }

    private void OnTriggerEnter(Collider other)
    {
        var grabbable = other.GetComponent<GrabbableObject>();
        if (grabbable != null)
        {
            hoveredObject = grabbable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var grabbable = other.GetComponent<GrabbableObject>();
        if (grabbable == hoveredObject)
        {
            hoveredObject = null;
        }
    }
    public void GrabLever()
    {
        if (hoveredObject != null)
        {
            grabbedObject = hoveredObject;
            grabbedObject.OnLeverGrab(controller);
        }
    }

    public void ReleaseLever()
    {
        if (grabbedObject != null)
        {
            grabbedObject.OnLeverRelease(controller);
        }
    }
}

