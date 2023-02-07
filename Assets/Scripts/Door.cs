using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool isOpen = false;
    private BoxCollider2D bc;
    private SpriteRenderer sr;

    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isOpen) { sr.enabled = false; }
        else { sr.enabled = true; }
    }

    public void toggleDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            bc.isTrigger = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else
        {
            isOpen = false;
            bc.isTrigger = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
