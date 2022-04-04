using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour
{
    private GameObject[] mediumCon;
    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            mediumCon = GameObject.FindGameObjectsWithTag("MediumConsumable");
        }
    }

    void ConsumeMedium()
    {
        foreach (var item in mediumCon)
        {
            
        }
    }


}

