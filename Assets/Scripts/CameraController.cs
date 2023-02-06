using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ball = GameObject.Find("Ball");

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if(ball.gameObject.transform.position.y > 5) {
            newPosition.y = ball.gameObject.transform.position.y - 5;
            transform.position = newPosition;
        }
    
    }

    
}
