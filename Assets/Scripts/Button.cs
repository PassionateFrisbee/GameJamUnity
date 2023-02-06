using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    //public bool pushed;

    //private BoxCollider2D bc;

    public GameObject door;

    
    void Start()
    {
        //pushed = false;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            //lose = true;
            //Instantiate(loseText, new Vector3(0, 0, 0), Quaternion.identity);

            Door doorController = door.gameObject.GetComponent<Door>();
            doorController.toggleDoor();
            Destroy(this.gameObject);
            
        }
    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
