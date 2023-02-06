using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWellDown : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider2D bc;

    public float lowGravity;
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            Rigidbody2D rbOther = other.gameObject.GetComponent<Rigidbody2D>();
            if(rbOther != null) {
                rbOther.gravityScale = lowGravity;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            Rigidbody2D rbOther = other.gameObject.GetComponent<Rigidbody2D>();
            if(rbOther != null) {
                rbOther.gravityScale = 1f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
