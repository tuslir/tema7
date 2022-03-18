using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static float movementSpeed = 7;

    CharacterController controller;
    Vector3 movementDir;
    Vector3 velocity;
    public GameObject pauseMenu;
    private bool isPaused;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        //MOVEMENT WITH CHARACTER CONTROLLER
        controller.Move(velocity * Time.deltaTime);
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movementDir = transform.right * x + transform.forward * z;

        Vector3 motion = movementDir * movementSpeed * Time.deltaTime;
        controller.Move(motion);


        //PauseMenu med toggle funksjon
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }

    }
}
