using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVolume : MonoBehaviour
{
    public WaterFlow faucetFlow;
    public WaterFlow plugFlow;
    private float waterLevelMinZ;
    private float waterLevelMaxZ;
    private Vector3 waterLevelMin;
    private Vector3 waterLevel;
    private float waterLevelZ;
    [SerializeField]
    private float fillCorrection = 1f;

    private void Start()
    {
        waterLevelMinZ = 0f;
        waterLevelMaxZ = 0.0013f;
        waterLevelMin = new Vector3(0, 0, waterLevelMinZ);
        transform.localPosition = waterLevelMin;
    }

    void Update()
    {
        waterLevelZ = (faucetFlow.flowTime - plugFlow.flowTime) * fillCorrection;
        waterLevelZ = Mathf.Clamp(waterLevelZ, waterLevelMinZ, waterLevelMaxZ);
        waterLevel = new Vector3(0, 0, waterLevelZ);
        transform.localPosition = waterLevel;
    }
}
