using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpikeWall : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    BoxCollider2D bc;

    public GameObject loseText;
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
         Vector2 movement = new Vector2(1, 0);
        rb.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            Instantiate(loseText, new Vector3(0, 0, 0), Quaternion.identity);
        }

        if(!other.gameObject.CompareTag("UI") && !other.gameObject.CompareTag("Bar"))
            Destroy(other.gameObject);
    }

}
