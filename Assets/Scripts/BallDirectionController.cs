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

    private Rigidbody2D rb;

    private bool direction_ready = false;

    float magnitude = 2.5f;
    public GameObject speedBars;

    public bool canJump;

    public GameObject restartbutton;

    public AudioClip clip;
    private AudioSource source;

    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse_position = GetMouseWorldPosition();
        UpdateMouse(mouse_position);

        Vector2 dottedLine_pos = dottedLineStart.transform.position;
        Vector2 mouse_pos = mouse.transform.position;
        Vector2 ball_direction = mouse_pos - dottedLine_pos;


        ball_direction.Normalize();

        if (Input.GetKeyDown(KeyCode.Mouse0) && canJump)
        {
            direction_ready = true;

            Instantiate(speedBars,
                        new Vector3(restartbutton.transform.position.x + 4, restartbutton.transform.position.y - 5.0f, restartbutton.transform.position.z),
                        Quaternion.identity);
            speedBars.transform.parent = cam.transform;

            timer_start = true;
        }

        if (timer_start)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                magnitude += 2.5f;
                timer = spriteGap;
            }
        }

        if (direction_ready == true && Input.GetKeyUp(KeyCode.Mouse0))
        {
            magnitude %= 27.5f;
            Vector2 movement = new Vector2(ball_direction.x * magnitude, ball_direction.y * magnitude);
            rb.velocity = movement;

            magnitude = 2.5f;
            canJump = false;
            direction_ready = false;
            timer_start = false;
            timer = 0.2f;

            Debug.Log(source);
            source.PlayOneShot(clip);
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
