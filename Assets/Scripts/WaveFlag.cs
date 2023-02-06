using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFlag : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;

    private SpriteRenderer mySpriteRenderer;    

    public float spriteTimer = .1f;

    private float timer;

    void changeSprite() {
        if(mySpriteRenderer.sprite == sprite1) {
            mySpriteRenderer.sprite = sprite2;
        }
        else if(mySpriteRenderer.sprite == sprite2) {
            mySpriteRenderer.sprite = sprite3;
        }
        else if(mySpriteRenderer.sprite == sprite3) {
            mySpriteRenderer.sprite = sprite4;
        }
        else if(mySpriteRenderer.sprite == sprite4) {
            mySpriteRenderer.sprite = sprite5;
        }
        else if(mySpriteRenderer.sprite == sprite5) {
            mySpriteRenderer.sprite = sprite6;
        }
        else if(mySpriteRenderer.sprite == sprite6) {
            mySpriteRenderer.sprite = sprite1;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        timer = spriteTimer;
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            changeSprite();
            timer = spriteTimer;
        }
    }
}
