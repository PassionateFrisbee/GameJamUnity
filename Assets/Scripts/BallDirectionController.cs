using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallDirectionController : MonoBehaviour
{
    public GameObject dottedLineStart;
    public GameObject mouse;
    public LineRenderer dottedLineRenderer;
    private Quaternion start_rotation = Quaternion.AngleAxis(0, Vector3.forward);
    public float smooth = 2.0f;
    public float speed = 2.0f;
    private bool isLocked = false;

    private Rigidbody2D rb;

    private bool ready = false;
    public float magnitude = 25;
    public float scaleFactor = 10;
    public GameObject speedBars;
    PowerArrow arrow;
    public Vector3 barPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = start_rotation;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse_position = GetMouseWorldPosition();
        UpdateMouse(mouse_position);

        Vector2 ball_pos = transform.position;
        //Vector2 dottedLine_pos = dottedLineStart.transform.position;
        Vector2 mouse_pos = mouse.transform.position;
        // Vector2 mouse_direction = mouse_pos - dottedLine_pos; **possible raycasting
        Vector2 ball_direction = mouse_pos - ball_pos;
        ball_direction.Normalize();

        dottedLineRenderer.enabled = true;

        float angle_rad = Mathf.Atan2(ball_direction.y, ball_direction.x);
        float angle_deg = Mathf.Rad2Deg * angle_rad - 90;

        transform.rotation = Quaternion.AngleAxis(angle_deg, Vector3.forward);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Direction vector: " + ball_direction);
            ready = true;
            //barPosition = new Vector3(0, -4, 0) + transform.position;
            //Instantiate(speedBars, barPosition, Quaternion.identity);
            Vector2 movement = new Vector2(ball_direction.x * magnitude, ball_direction.y * magnitude);
            rb.velocity = movement;
        }

        //else if (ready == true)
        //{
        //    //magnitude = arrow.getMagnitude() * scaleFactor;
        //    rb.velocity = ball_direction * magnitude;
        //}

    }

    Vector3 GetMouseWorldPosition()
    {
        // this gets the current mouse position (in screen coordinates) and transforms it into world coordinates
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // the camera is on z = -10, so all screen coordinates are on z = -10. To be on the same plane as the game, we need to set z to 0
        mouseWorldPos.z = 0;

        return mouseWorldPos;
    }

    void UpdateMouse(Vector3 newMousePosition)
    {
        mouse.transform.position = newMousePosition;
        dottedLineRenderer.SetPosition(0, dottedLineStart.transform.position);
        dottedLineRenderer.SetPosition(1, mouse.transform.position);
    }

    void SmoothLookAt(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
    }
}
