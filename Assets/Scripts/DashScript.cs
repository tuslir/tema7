using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    PlayerMovement moveScript;
    Rigidbody rb;
    public Vector3 targetPosRight;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;

    public bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            DashRight();
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void DashRight()
    {
        //moveScript.controller.Move(transform.right * dashSpeed * Time.deltaTime);
        this.transform.position = Vector3.MoveTowards(transform.position, (transform.position + targetPosRight), dashTime * Time.deltaTime);
        //rb.AddForce(transform.right * dashSpeed, ForceMode.Impulse);
        Debug.Log("Is Dashing");
    }

    /*IEnumerator DashRight()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.motion * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }*/


}
