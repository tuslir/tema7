using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public GameObject[] midCon;
    public GameObject volcano;

    // Start is called before the first frame update
    void Start()
    {
        // Finds all objects with the same tag and puts them to an array
        midCon = GameObject.FindGameObjectsWithTag("MidConsumable");
        volcano = GameObject.FindGameObjectWithTag("Volcano");
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is a certain lvl, it goes through the array and changes every object's collider
        if(PlayerStates.state == PlayerStates.playerLvL.lvl2 || PlayerStates.state == PlayerStates.playerLvL.lvl3)
        {
            foreach (var i in midCon)
            {
                i.GetComponent<CompositeCollider2D>().isTrigger = true;
            }
        }
        else if(PlayerStates.state != PlayerStates.playerLvL.lvl2 || PlayerStates.state != PlayerStates.playerLvL.lvl3)

            {

                foreach (var i in midCon)

                {

                    i.GetComponent<CompositeCollider2D>().isTrigger = false;

                }

            }

        if (PlayerStates.state == PlayerStates.playerLvL.lvl3)
        {
            volcano.GetComponent<CompositeCollider2D>().isTrigger = true;
        }
        else
        {
            volcano.GetComponent<CompositeCollider2D>().isTrigger = false;
        }
    }
}
