using UnityEngine;
using UnityEngine.Video;

public class PlayerMovement : MonoBehaviour
{
    public enum State { Normal, Dashing }

    [Header("Components")]
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;


    [Header("Stored Variables")]
    [SerializeField] private GameObject vp;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float knockBack;
    [SerializeField] private AudioClip walkClip;
    private float cdTimer = 0;
    private float maxCDTimer = 3f;
    public static Vector3 moveDir;
    private Vector3 dashDir;
    public State states;

    [Header("Bools")]
    private bool canDash;
    private bool isPaused;
    private bool isWalking;
    public static bool isDashing;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        states = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        cdTimer += Time.deltaTime;

        if (cdTimer >= maxCDTimer)
        {
            canDash = true;
        }

        switch (states)
        {



            case State.Normal:
                float moveX = 0f;
                float moveY = 0f;

                if (!vp.GetComponent<VideoPlayer>().clip)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        moveY = +1f;
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        moveX = -1f;
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        moveY = -1f;
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        moveX = +1f;
                    }

                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                    {
                        isWalking = true;
                    }
                    else isWalking = false;

                    moveDir = new Vector3(moveX, moveY).normalized;

                    if (Input.GetKeyDown(KeyCode.Space) && canDash)
                    {
                        dashDir = moveDir;
                        dashSpeed = 100f;
                        states = State.Dashing;
                        isDashing = true;
                        canDash = false;
                        cdTimer = 0f;
                    }
                }

                if (isWalking && !AudioManager.isPlayingClip)
                {
                    FindObjectOfType<AudioManager>().Play("Flamey_footsteps1.8");
                }

                if (!isWalking)
                {
                    FindObjectOfType<AudioManager>().Stop("Flamey_footsteps1.8");
                }

                if (states == State.Dashing)
                {
                    FindObjectOfType<AudioManager>().Play("Flamey_DashV1");
                }

                break;
            case State.Dashing:
                float dashSpeedDropMultiplier = 5f;
                dashSpeed -= dashSpeed * dashSpeedDropMultiplier * Time.deltaTime;

                float dashSpeedMinimum = 50f;
                if (dashSpeed < dashSpeedMinimum)
                {
                    states = State.Normal;
                    isDashing = false;
                }
                break;


                /*//PauseMenu med toggle funksjon
                if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
                {
                    isPaused = true;
                    pauseMenu.SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
                {
                    pauseMenu.SetActive(false);
                    isPaused = false;
                }
                */

        }

    }
    private void FixedUpdate()
    {
        switch (states)
        {
            case State.Normal:
                rb.velocity = moveDir * movementSpeed * Time.deltaTime;
                break;
            case State.Dashing:
                rb.velocity = dashDir * dashSpeed;
                break;
        }

        if (CollideScript.isCrashing)
        {
            rb.AddForce(-moveDir * knockBack, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("Flamey_KnockBack");
        }


    }
}
