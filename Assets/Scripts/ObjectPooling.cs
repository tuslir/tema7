using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling SharedInstance;
    public List<GameObject> pooledObjects;
    public int amountToPool;
    public GameObject objectToPool;

    private void Awake()
    {
        SharedInstance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
         GameObject tmp;
         for (int i = 0; i < amountToPool; i++)
         {
             tmp = Instantiate(objectToPool);
             tmp.SetActive(false);
             pooledObjects.Add(tmp);
         }
     }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }



}

