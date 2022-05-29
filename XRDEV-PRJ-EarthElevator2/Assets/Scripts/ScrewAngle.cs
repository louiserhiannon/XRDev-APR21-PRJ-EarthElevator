using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewAngle : MonoBehaviour
{
    [SerializeField]
    private float lastScrewAngle;
    [SerializeField]
    private float newScrewAngle;
    [SerializeField]
    private float screwMovement;
    [SerializeField]
    public float distance;
    private HingeJoint screw;
    private float distancePerDegree;
    public ScrewMovement screwPosition;
    public float newTransform;

    void Start()
    {
        screw = GetComponent<HingeJoint>();
        lastScrewAngle = 0f;
        distancePerDegree = 0.08f / 3;

}

void Update()
    {
        newScrewAngle = screw.angle;
        screwMovement = newScrewAngle - lastScrewAngle;
        if(screwMovement < -300)
        {
            screwMovement += 360;
        }
        else if(screwMovement > 300)
        {
            screwMovement -= 360;
        }

        distance = screwMovement / 360 * distancePerDegree;
        lastScrewAngle = screw.angle;
        newTransform = screwPosition.screwY;
    }
}
