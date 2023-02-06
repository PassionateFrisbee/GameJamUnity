using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerArrow : MonoBehaviour
{
    //public Sprite[] frames;
    public float framesPerSecond = 5;
    SpriteRenderer sr;
    int currentFrameIndex = 5;
    public float frameTimer;
    public float magnitude;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        frameTimer = (1f / framesPerSecond);
        currentFrameIndex = 0;
    }

    void Update()
    {
        //frameTimer -= Time.deltaTime;

        //if (frameTimer <= 0)
        //{
        //    currentFrameIndex++;
        //    if (currentFrameIndex >= frames.Length)
        //    {
        //        Destroy(gameObject);
        //        return;
        //    }
        //    frameTimer = (1f / framesPerSecond);
        //    sr.sprite = frames[currentFrameIndex];
        //}

        magnitude = currentFrameIndex;
    }

    public float getMagnitude()
    {
        return magnitude;
    }
}
