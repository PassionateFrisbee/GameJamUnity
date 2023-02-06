using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D bc;

    public GameObject winText;

    public string nextScene;

    public float timeTillNextScene;

    public bool win = false;
    
    void OnTriggerEnter2D(Collider2D other) {
        //SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        if(other.gameObject.CompareTag("Ball")) {
            win = true;
            Instantiate(winText, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(win) {
            timeTillNextScene -= Time.deltaTime;
            if(timeTillNextScene <= 0) {
                SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
            }
        }
        
    }
}
