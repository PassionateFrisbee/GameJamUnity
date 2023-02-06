using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loseText;

    private PolygonCollider2D pc;
    void Start()
    {
        pc = gameObject.GetComponent<PolygonCollider2D>();
        pc.isTrigger = true;
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            Instantiate(loseText, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
