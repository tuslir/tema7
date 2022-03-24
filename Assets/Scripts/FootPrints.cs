using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrints : MonoBehaviour
{
    [SerializeField] private GameObject footPrints;
    [SerializeField] private Vector3 offset;
    private float totalTime = 0;
    [SerializeField] private LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, whatIsGround);
        Debug.DrawRay(transform.position, -transform.up);

        totalTime += Time.deltaTime;
        if(totalTime>.25f)
        {
        //Instantiate(footPrints, hit.normal, footPrints.transform.rotation);
            totalTime = 0f;
          //  Destroy(footPrints, 4);
        }
    }
}
