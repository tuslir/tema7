using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public GameObject[] midCon;

    // Start is called before the first frame update
    void Start()
    {
        midCon = GameObject.FindGameObjectsWithTag("MediumConsumable");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            foreach (var i in midCon)
            {
                i.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }
}
