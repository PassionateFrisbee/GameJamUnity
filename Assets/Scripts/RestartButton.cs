using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private void OnMouseDown() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);    
    }
}
