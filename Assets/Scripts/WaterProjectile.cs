using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    public float projectileSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if(this.GetComponent<SpriteRenderer>().enabled)
        {
            this.transform.position = Vector3.Lerp(GetComponentInParent<Transform>().position, GetComponentInParent<Transform>().position + new Vector3(0, 2, GetComponentInParent<Transform>().rotation.z), projectileSpeed);
        }
    }
}
