using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isOpen = false;
    private BoxCollider2D bc;

    public void toggleDoor() {
        if(!isOpen) {
            isOpen = true;
            bc.isTrigger = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        } else {
            isOpen = false;
            bc.isTrigger = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
