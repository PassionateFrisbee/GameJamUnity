using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private BoxCollider2D bc;

    public GameObject destination;

    public bool canTeleport;

    public float cooldown;

    private float timer;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball") && canTeleport) {
            Vector3 newPosition = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
            Teleport otherTele = destination.gameObject.GetComponent<Teleport>();
            if(otherTele != null) {
                otherTele.canTeleport = false;
            }
            other.gameObject.transform.position = newPosition;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
        canTeleport = true;
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canTeleport) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                canTeleport = true;
                timer = cooldown;
            }
        }
    }
}
