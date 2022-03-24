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

    public Vector3 motion;
    Vector3 movementDir;
    Vector3 velocity;
    private bool isPaused;


    void Start()
    {
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
        float y = Input.GetAxisRaw("Vertical");

        movementDir = transform.right * x + transform.up * y;
        motion = movementDir * movementSpeed * Time.deltaTime;
        controller.Move(motion);



        //definerer hvor animator skal hente floats
        anim.SetFloat("horizontal", Mathf.Abs(motion.x));
        anim.SetFloat("vertical", Mathf.Abs(motion.y));



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
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }


    }
}
