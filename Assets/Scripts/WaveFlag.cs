using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFlag : MonoBehaviour
{ 
    private SpriteRenderer sr;
    private int frameIndex;
    public Sprite[] frames;
    public float fps = 3;
    private float sliderTimer;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sliderTimer = (1f / fps);
        frameIndex = 0;
    }

    void FixedUpdate()
    {
        sliderTimer -= Time.deltaTime;
        if (sliderTimer <= 0)
        {
            frameIndex++;
            if (frameIndex >= frames.Length) { frameIndex = 0; }

            sliderTimer = (1f / fps);
            sr.sprite = frames[frameIndex];
        }
    }
}