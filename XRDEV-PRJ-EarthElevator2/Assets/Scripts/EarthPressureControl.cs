using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPressureControl : MonoBehaviour
{
    public ScrewMovement screwMovement;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField]
    private float blendRatio;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        //Calculate Blend Shape
        blendRatio = Mathf.Clamp(screwMovement.screwRelativePos * 100, 0, 100);
        skinnedMeshRenderer.SetBlendShapeWeight(0, blendRatio);

        //Calculate Pressure
    }
}
