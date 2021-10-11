using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterCoreFlow : MonoBehaviour
{
    private Renderer outerCore;
    public float maxTileX;
    public float minTileX;
    public float maxTileY;
    public float minTileY;
    public float flowSpeedX;
    public float flowSpeedY;
    public float flowOffset;
    public float cosTime;
    public float textureScaleX;
    public float textureScaleY;

    private Vector2 textureMorph;
    void Start()
    {
        outerCore = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cosTime = Mathf.Cos(Time.time);
        Debug.Log(cosTime);
        textureScaleX = minTileX + (1 + Mathf.Cos(Time.time * flowSpeedX)) / 2 * (maxTileX - minTileX);
        textureScaleY = minTileY + (1 + Mathf.Cos(Time.time * flowSpeedY + flowOffset)) / 2 * (maxTileY - minTileY);
        textureMorph = new Vector2(textureScaleX, textureScaleY);
        outerCore.materials[0].mainTextureScale = textureMorph;
    }
}
