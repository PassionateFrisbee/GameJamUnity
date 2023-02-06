using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider2D bc;
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            BallDirectionController bdc = other.gameObject.GetComponent<BallDirectionController>();
            if(bdc != null) {
                bdc.canJump = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            BallDirectionController bdc = other.gameObject.GetComponent<BallDirectionController>();
            if(bdc != null) {
                bdc.canJump = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            BallDirectionController bdc = other.gameObject.GetComponent<BallDirectionController>();
            if(bdc != null) {
                bdc.canJump = false;
            }
        }
    }
}
