using System.Collections;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsObstacle;
    [SerializeField] private Vector3 targetPosRight;
    [SerializeField] private Vector3 targetPosLeft;
    [SerializeField] private Vector3 targetPosForward;
    [SerializeField] private Vector3 targetPosBack;
    [SerializeField] private float dashCD;
    [SerializeField] private float dashSpeed;

    public static bool isDashing;
    public bool canDash = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
            dashCD -= Time.deltaTime;
        }

        if (dashCD <= 0)
        {
            canDash = true;
        }

        //Check if Dash requirements are met and which direction the player wants to dash towards
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && !isDashing && canDash)
        {
            isDashing = true;
            StartCoroutine(DashRight());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && !isDashing && canDash)
        {
            isDashing = true;
            StartCoroutine(DashLeft());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !isDashing && canDash)
        {
            isDashing = true;
            StartCoroutine(DashForward());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.S) && !isDashing && canDash)
        {
            isDashing = true;
            StartCoroutine(DashBack());
        }

    }


    IEnumerator DashRight()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashSpeed)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosRight, targetPosRight.x, whatIsObstacle);
            if (hit.collider != null)
            {
                transform.position = Vector3.Lerp(transform.position, hit.point, dashSpeed * Time.deltaTime);
            }
            else transform.position = Vector3.Lerp(transform.position, targetPosRight, dashSpeed * Time.deltaTime);

            yield return null;
        }
        canDash = false;
        isDashing = false;
        dashCD = 3;

    }

    IEnumerator DashLeft()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashSpeed)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosLeft, targetPosLeft.x, whatIsObstacle);
            if (hit.collider != null)
            {
                transform.position = Vector3.Lerp(transform.position, hit.point, dashSpeed * Time.deltaTime);
            }
            else transform.position = Vector3.Lerp(transform.position, targetPosLeft, dashSpeed * Time.deltaTime);

            yield return null;
        }
        canDash = false;
        isDashing = false;
        dashCD = 3;
    }

    IEnumerator DashForward()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashSpeed)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosForward, targetPosForward.x, whatIsObstacle);
            if (hit.collider != null)
            {
                transform.position = Vector3.Lerp(transform.position, hit.point, dashSpeed * Time.deltaTime);
            }
            else transform.position = Vector3.Lerp(transform.position, targetPosForward, dashSpeed * Time.deltaTime);

            yield return null;
        }
        canDash = false;
        isDashing = false;
        dashCD = 3;
    }

    IEnumerator DashBack()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashSpeed)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosBack, targetPosBack.x, whatIsObstacle);
            if (hit.collider != null)
            {
                transform.position = Vector3.Lerp(transform.position, hit.point, dashSpeed * Time.deltaTime);
            }
            else transform.position = Vector3.Lerp(transform.position, targetPosBack, dashSpeed * Time.deltaTime);

            yield return null;
        }
        canDash = false;
        isDashing = false;
        dashCD = 3;
    }

    // Cooldown for dashing
    void DashCD()
    {
        isDashing = false;
    }

}
