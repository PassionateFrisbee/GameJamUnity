using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerArrow : MonoBehaviour
{
    public Sprite[] frames;
    SpriteRenderer sr;
    int currentFrameIndex;
    private float timer;
    public float spriteGap = 0.2f;
    //private GameObject ball;

    private GameObject cam;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentFrameIndex = 0;
        cam = GameObject.Find("Main Camera");
        transform.parent = cam.transform;
        // ball = GameObject.Find("Ball");
        // transform.parent = ball.transform;
    }

    // void FixedUpdate() {
    //     transform.position = new Vector3(ball.transform.position.x - 3, transform.position.y, transform.position.z);
    // }

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
