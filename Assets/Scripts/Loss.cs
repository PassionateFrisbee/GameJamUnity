using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loss : MonoBehaviour
{

    public float timeTillNextScene;

    // Update is called once per frame
    void Update()
    {
        timeTillNextScene -= Time.deltaTime;
        if(timeTillNextScene <= 0) 
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);    
        };
    }
}
