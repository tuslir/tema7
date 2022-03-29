using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosRight;
    [SerializeField] private Vector3 targetPosLeft;
    [SerializeField] private Vector3 targetPosForward;
    [SerializeField] private Vector3 targetPosBack;
    [SerializeField] private float dashCD;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;

    public bool isDashing;

    // Update is called once per frame
    void Update()
    {
        //Check if Dash requirements are met and which direction the player wants to dash towards
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && !isDashing)
        {
            StartCoroutine(DashRight());
            isDashing = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && !isDashing)
        {
            StartCoroutine(DashLeft());
            isDashing = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !isDashing)
        {
            StartCoroutine(DashForward());
            isDashing = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.S) && !isDashing)
        {
            StartCoroutine(DashBack());
            isDashing = true;
        }

    }

   
    IEnumerator DashRight()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosRight, dashTime * Time.deltaTime);

            Invoke("DashCD", dashCD);
            yield return null;
        }
    }

    IEnumerator DashLeft()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosLeft, dashTime * Time.deltaTime);

            Invoke("DashCD", dashCD);
            yield return null;
        }
    }

    IEnumerator DashForward()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosForward, dashTime * Time.deltaTime);

            Invoke("DashCD", dashCD);
            yield return null;
        }
    }

    IEnumerator DashBack()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosBack, dashTime * Time.deltaTime);

            Invoke("DashCD", dashCD);
            yield return null;
        }
    }

    // Cooldown for dashing
    void DashCD()
    {
        isDashing = false;
    }

}
