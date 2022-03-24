using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FootPrints : MonoBehaviour
{
    [SerializeField] private GameObject footPrints;
    [SerializeField] private Vector3 offset;
    [SerializeField] private LayerMask whatIsGround;
    private float totalTime = 0;

    public static ObjectPool<FootPrints> SharedInstance;
    public List<GameObject> pooledObjects;
    public int amountToPool;

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

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }







}
