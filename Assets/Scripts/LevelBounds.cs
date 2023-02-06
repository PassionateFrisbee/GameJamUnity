using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBounds : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D bc;

    //public bool lose = false;

    public float timeTillNextScene;

    public GameObject loseText;
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            //lose = true;
            Instantiate(loseText, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(lose) {
    //         timeTillNextScene -= Time.deltaTime;
    //         if(timeTillNextScene <= 0) 
    //         {
    //             Scene scene = SceneManager.GetActiveScene();
    //             SceneManager.LoadScene(scene.name);    
    //         };
    //     }
    // }
}
