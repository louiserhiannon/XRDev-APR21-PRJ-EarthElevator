using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelObjects : MonoBehaviour
{
    //Controls movement and clearing of game objects added to shaft during level interactivities

    private Vector3 resetPosition = new Vector3(1.281f, 2.989f, 0.339f);
    public Transform shaftMovement;

    public void MoveWithShaft(Transform activePoint)
    {
        transform.SetParent(activePoint.transform);
    }

    public void ResetLevelTransform()
    {
        //Destroy all game objects (as long as there are children, they will be destroyed
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        //reset position
        transform.SetParent(shaftMovement);
        transform.position = resetPosition;
    }

}
