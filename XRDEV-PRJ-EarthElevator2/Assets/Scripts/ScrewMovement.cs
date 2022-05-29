using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewMovement : MonoBehaviour
{
    public ScrewAngle screwAngle;
    private float screwMaxY;
    private float screwMinY;
    public float screwY;
    public float screwRelativePos;
    private Vector3 screwStartPosition;
    private Vector3 screwEndPosition;


    private void Start()
    {
        screwMaxY = 0.232f;
        screwMinY = 0.167f;

        //Set Position
        screwStartPosition = new Vector3(0, (screwMaxY - 0.0002f), 0);
        transform.localPosition = screwStartPosition;

        screwEndPosition = new Vector3(0, (screwMinY + 0.0002f), 0);
    }
    void Update()
    {
        //move screw between min and max positions
        if(transform.localPosition.y <= screwMaxY && transform.localPosition.y >= screwMinY)
        {
            transform.Translate(0, 0, screwAngle.distance);
        }
        else if (transform.position.y > screwMaxY)
        {
            transform.localPosition = screwStartPosition;
        }
        else if (transform.position.y < screwMinY)
        {
            transform.localPosition = screwEndPosition;
        }


        //calculate relative position
        screwY = transform.localPosition.y;
        screwRelativePos = (screwY - screwMaxY) / (screwMinY - screwMaxY);
    }
}
