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
    public Vector3 barPosition;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ready = true;
            barPosition = new Vector3(0, -4, 0) + transform.position;
            Instantiate(speedBars, barPosition, Quaternion.identity);
        }

        else if (ready == true)
        {
            magnitude = arrow.getMagnitude() * scaleFactor;
        }
    }
}
