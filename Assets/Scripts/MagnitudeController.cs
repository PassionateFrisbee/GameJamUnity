using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnitudeController : MonoBehaviour
{
    private bool ready = false;
    public float magnitude;
    public float scaleFactor = 10;
    public GameObject speedBars;
    PowerArrow arrow;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ready = true;
            //change location to where this is instantiated! (maybe a little to left of where ball is?)
            Instantiate(speedBars, transform.position, Quaternion.identity);
        }

        else if (ready == true)
        {
            magnitude = arrow.getMagnitude() * scaleFactor;
        }
    }
}
