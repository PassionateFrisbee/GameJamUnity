using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWallMovement : MonoBehaviour
{
    public float topX;
    public float bottomX;

    public float speed;
    public bool movingLeft = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        if(movingLeft) {
            if(transform.position.x < (topX)) {
                movement.x += speed;
            } else {
                movingLeft = false;
            }
        } else if (!movingLeft) {
            if(transform.position.x > (bottomX)) {
                movement.x -= speed;
            } else {
                movingLeft = true;
            }
        }
        rb.velocity = new Vector2(movement.x, movement.y);
    }
}
