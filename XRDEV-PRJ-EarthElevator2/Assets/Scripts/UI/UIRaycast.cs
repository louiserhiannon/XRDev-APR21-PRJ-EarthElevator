using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRaycast : MonoBehaviour
{

    private VRInput controller;
    private LineRenderer line;
    private Vector3 hitPosition;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<VRInput>();
        line = GetComponent<LineRenderer>();
        line.enabled = false;

        controller.OnGrip.AddListener(RaycastUI); // hooks into event identified in VRInput and connects it to RaycastUI()
        controller.OnGripUp.AddListener(RaycastUIStop); // hooks into event identified in VRInput and connects it to RaycastUIStop()

    }


    public void RaycastUI()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            hitPosition = hit.point;

            //generate line
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hitPosition);

            line.enabled = true;
        }

    }

    public void RaycastUIStop()
    {
        line.enabled = false;
    }

}
