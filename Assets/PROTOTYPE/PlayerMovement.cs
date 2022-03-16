using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;

    CharacterController controller;
    Vector3 movementDir;
    Vector3 velocity;

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


    }
}
