using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundHelper : MonoBehaviour
{
    public Renderer backRenderer;
    private float speedY = 0.01f;
    private float speedX = 0.003f;
    void Update()
    {
        if (backRenderer != null)
        {
            backRenderer.material.mainTextureOffset = new Vector2(speedX * Time.time, speedY * Time.time);
        }
    }
}
