using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static float movementSpeed = 7;

    public CharacterController controller;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public GameObject pauseMenu;
    Rigidbody rb;

    public Vector3 motion;
    Vector3 movementDir;
    Vector3 velocity;
    private bool isPaused;

    [Header("Dash Variables")]
    [SerializeField] private Vector3 dashRight;
    [SerializeField] private Vector3 dashLeft;
    [SerializeField] private Vector3 dashForward;
    [SerializeField] private Vector3 dashBack;
    [SerializeField] private float dashThrust;
    [SerializeField] private int dashCDTimer;
    [SerializeField] private KeyCode W;
    [SerializeField] private KeyCode A;
    [SerializeField] private KeyCode S;
    [SerializeField] private KeyCode D;
    public bool canDashRight;
    private bool canDashLeft;
    private bool canDashForward;
    private bool canDashBack;
    public bool isDashing;





    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        //MOVEMENT WITH CHARACTER CONTROLLER
        controller.Move(velocity * Time.deltaTime);
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movementDir = transform.right * x + transform.forward * z;
        motion = movementDir * movementSpeed * Time.deltaTime;
        controller.Move(motion);



        //definerer hvor animator skal hente floats
        //anim.SetFloat("horizontal", Mathf.Abs(motion.x));
        //anim.SetFloat("vertical", Mathf.Abs(motion.z));



        //flip character sprite
        if (x < 0)
        {
            if (spriteRenderer.flipX != false)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (x > 0)
        {
            if (spriteRenderer.flipX != true)
            {
                spriteRenderer.flipX = true;
            }
        }


        //PauseMenu med toggle funksjon
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }

        /*
        if (Physics.Linecast(transform.position, dashRight))
        {
            canDashRight = false;
        }
        else canDashRight = true;

        if (Physics.Linecast(transform.position, dashLeft))
        {
            canDashLeft = false;
        }
        else canDashLeft = true;

        if (Physics.Linecast(transform.position, dashForward))
        {
            canDashForward = false;
        }
        else canDashForward = true;

        if (Physics.Linecast(transform.position, dashBack))
        {
            canDashBack = false;
        }
        else canDashBack = true;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && canDashRight && Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(DashRight());
            //dashSlider.value = dashCDTimer;
            //currentDashCDTimer = dashCDTimer;
        }*/
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, dashRight);
    }

    public IEnumerator DashRight()
    {
        isDashing = true;
        Vector3 targetPos = new Vector3(transform.position.x + dashRight.x, transform.position.y, transform.position.z);
        while ((Vector3)transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * dashThrust);
            yield return new WaitForSeconds(0.001f);
        }
        
        yield return new WaitForSeconds(dashCDTimer);
        isDashing = false;
        yield return null;

    }*/


}
