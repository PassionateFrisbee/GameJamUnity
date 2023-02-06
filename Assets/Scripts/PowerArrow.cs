using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerArrow : MonoBehaviour
{
    public Sprite[] frames;
    SpriteRenderer sr;
    int currentFrameIndex;
    private float timer;
    private float spriteGap = 0.4f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentFrameIndex = 0;
    }

    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            sr.sprite = frames[currentFrameIndex % frames.Length];
            timer = spriteGap;
            currentFrameIndex++;
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Destroy(gameObject);
        }
        
    }
}
