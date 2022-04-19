using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum State { Normal, Dashing }

    [Header("Components")]
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;


    [Header("Stored Variables")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float knockBack;
    public static Vector3 moveDir;
    private Vector3 dashDir;
    private State state;

    [Header("Bools")]
    private bool isPaused;
    public static bool isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {

            case State.Normal:
                float moveX = 0f;
                float moveY = 0f;

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

                moveDir = new Vector3(moveX, moveY).normalized;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dashDir = moveDir;
                    dashSpeed = 100f;
                    state = State.Dashing;
                    isDashing = true;
                }
                break;
            case State.Dashing:
                float dashSpeedDropMultiplier = 5f;
                dashSpeed -= dashSpeed * dashSpeedDropMultiplier * Time.deltaTime;

                float dashSpeedMinimum = 50f;
                if (dashSpeed < dashSpeedMinimum)
                {
                    state = State.Normal;
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
        switch (state)
        {
            case State.Normal:
                rb.velocity = moveDir * movementSpeed * Time.deltaTime;
                break;
            case State.Dashing:
                rb.velocity = dashDir * dashSpeed;
                break;
        }

        if(CollideScript.isCrashing)
        {
            rb.AddForce(-moveDir * knockBack, ForceMode2D.Impulse);
        }


    }
}
