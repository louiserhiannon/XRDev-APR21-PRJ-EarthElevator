using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public Rigidbody rigidBody; //expose rigidbody so it can be seen by VRGrab

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnLeverGrab(VRInput hand)
    {
        if (hand.GetComponent<FixedJoint>() == null)
        {
            FixedJoint fx = hand.gameObject.AddComponent<FixedJoint>();
            fx.connectedBody = rigidBody;
            fx.enableCollision = false;
            rigidBody.isKinematic = false;
        }
    }

    public void OnLeverRelease(VRInput hand)
    {
        FixedJoint fx = hand.GetComponent<FixedJoint>();
        Destroy(fx);
        rigidBody.isKinematic = true;
    }
}
