using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveFriction : MonoBehaviour
{

    private PolygonCollider2D pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = gameObject.GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("we have a hit");
        if(other.gameObject.CompareTag("Ball")) {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.drag = 1;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ball")) {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.drag = 0;
        }
    }
}
