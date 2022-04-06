using System.Collections;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectile1;
    [SerializeField] private GameObject projectile2;
    [SerializeField] private GameObject projectile3;
    [SerializeField] private GameObject projectile4;
    [SerializeField] private Vector2 shootUp;
    [SerializeField] private Vector2 shootLeft;
    [SerializeField] private Vector2 shootRight;
    [SerializeField] private Vector2 shootBack;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float maxTime;
    [SerializeField] private float timer;
    [SerializeField] private Transform proj1;
    [SerializeField] private Transform proj2;
    [SerializeField] private Transform proj3;
    [SerializeField] private Transform proj4;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Instantiate(projectile1, proj1);
        //projectile1.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(projectile2, proj2);
        projectile2.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(projectile3, proj3);
        projectile3.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(projectile4, proj4);
        projectile4.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        if (projectile1.GetComponent<SpriteRenderer>().enabled)
        {
            projectile1.transform.position = Vector2.Lerp(GetComponentInParent<Transform>().position, transform.up, projectileSpeed);
        }
        StartCoroutine(ShootProjectile());

    }

    void ResetProjectile()
    {
        projectile1.GetComponent<SpriteRenderer>().enabled = false;
        projectile1.transform.position = proj1.position;
        projectile2.GetComponent<SpriteRenderer>().enabled = false;
        projectile2.transform.position = proj2.position;
        projectile3.GetComponent<SpriteRenderer>().enabled = false;
        projectile3.transform.position = proj3.position;
        projectile4.GetComponent<SpriteRenderer>().enabled = false;
        projectile4.transform.position = proj4.position;
    }

    IEnumerator ShootProjectile()
    {
        //projectile1.GetComponent<SpriteRenderer>().enabled = true;
        //projectile1.transform.position = Vector2.MoveTowards(proj1.position, transform.up, projectileSpeed);
        projectile2.GetComponent<SpriteRenderer>().enabled = true;
        projectile2.transform.position = Vector2.MoveTowards(proj2.position, shootBack, projectileSpeed);
        projectile3.GetComponent<SpriteRenderer>().enabled = true;
        projectile3.transform.position = Vector2.MoveTowards(proj3.position, shootLeft, projectileSpeed);
        projectile4.GetComponent<SpriteRenderer>().enabled = true;
        projectile4.transform.position = Vector2.MoveTowards(proj4.position, shootRight, projectileSpeed);
        yield return new WaitForSeconds(3);
        ResetProjectile();
    }

}
