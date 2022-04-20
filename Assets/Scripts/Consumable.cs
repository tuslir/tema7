using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public GameObject[] midCon;

    // Start is called before the first frame update
    void Start()
    {
        // Finds all objects with the same tag and puts them to an array
        midCon = GameObject.FindGameObjectsWithTag("MidConsumable");
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is a certain lvl, it goes through the array and changes every object's collider
        if(PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            foreach (var i in midCon)
            {
                i.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        else if(PlayerStates.state != PlayerStates.playerLvL.lvl2)
            {
                foreach (var i in midCon)
                {
                    i.GetComponent<BoxCollider2D>().isTrigger = false;
                }
            }
    }
}
