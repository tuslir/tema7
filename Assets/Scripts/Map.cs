using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    
    [SerializeField] private GameObject objectToDisable;
    private bool mapOpen;

    private void Awake()
    {
        mapOpen = false;
        objectToDisable.GetComponent<Canvas>().enabled = false;
        //objectToDisable.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M) && !mapOpen)
        {
            //objectToDisable.SetActive(true);
            objectToDisable.GetComponent<Canvas>().enabled = true;
            mapOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.M) && mapOpen)
        {
            //objectToDisable.SetActive(false);
            objectToDisable.GetComponent<Canvas>().enabled = false;
            mapOpen = false;
        }


    }
}
