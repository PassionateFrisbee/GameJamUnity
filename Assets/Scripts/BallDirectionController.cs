using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

public class BallDirectionController : MonoBehaviour
{
    public GameObject dottedLineStart;
    public GameObject mouse;
    public LineRenderer dottedLineRenderer;

    private float timer;
    public float spriteGap = 0.2f;
    private bool timer_start = false;

    //private Vector3 power_position = new Vector3(-Screen.width / 2 + 2f, Screen.height - 1, 0f);
    private Rigidbody2D rb;

    private bool direction_ready = false;
    float magnitude = 2.2f;
    public float scaleFactor = 2;
    public GameObject speedBars;

    public bool canJump;

    public GameObject restartbutton;

    //public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //dottedLineRenderer.enabled = true;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse_position = GetMouseWorldPosition();
        UpdateMouse(mouse_position);

        Vector3 ball_pos = transform.position;
        Vector2 dottedLine_pos = dottedLineStart.transform.position;
        Vector2 mouse_pos = mouse.transform.position;
        //Vector2 mouse_direction = mouse_pos - dottedLine_pos; **possible raycasting
        Vector2 ball_direction = mouse_pos - dottedLine_pos;

        //Vector3 ball_direction = mouse_position - ball_pos;

        ball_direction.Normalize();

        if (Input.GetKeyDown(KeyCode.Mouse0) && canJump)
        {
            direction_ready = true;
            //Instantiate(speedBars, new Vector3(-6f, 3f, 0f), Quaternion.identity);

            //GameObject speedbars = Instantiate(speedBars,
            //            new Vector3(restartbutton.transform.position.x + 4, restartbutton.transform.position.y - 5.0f, restartbutton.transform.position.z),
            //            Quaternion.identity);
            //speedBars.transform.parent = cam.transform;

            //  GameObject speedbars = Instantiate(speedBars,
            //              new Vector3(transform.position.x - 3, transform.position.y, transform.position.z),
            //              Quaternion.identity);

            //GameObject ball = GameObject.Find("Ball");
            //speedBars.transform.parent = ball.transform;

            timer_start = true;
        }

        if (timer_start)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                magnitude += 2.2f;
                timer = spriteGap;
            }
        }

        if (direction_ready == true && Input.GetKeyUp(KeyCode.Mouse0))
        {
            magnitude %= 22;
            Vector2 movement = new Vector2(ball_direction.x * magnitude, ball_direction.y * magnitude);
            rb.velocity = movement;
            magnitude = 0.0f;

            canJump = false;
            direction_ready = false;
            timer_start = false;
            timer = 0.2f;

        }

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

}
