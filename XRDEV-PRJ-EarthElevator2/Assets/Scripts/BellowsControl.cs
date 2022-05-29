using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellowsControl : MonoBehaviour
{
    public LeverAngle leverAngle;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    //private Mesh skinnedMesh;
    //private int blendShapeCount;
    [SerializeField]
    private float blendRatio;

    private void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        //skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    //void Start()
    //{
    //    blendShapeCount = skinnedMesh.blendShapeCount;
    //}

    void Update()
    {
        blendRatio = Mathf.Clamp(leverAngle.leverValue * 100, 0, 100);
        skinnedMeshRenderer.SetBlendShapeWeight(0, blendRatio);
        
    }
}
