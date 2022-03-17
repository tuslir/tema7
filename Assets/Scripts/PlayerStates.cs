using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    //Test!! Vil vi ha med states spilleren kommer i som gir han forskjellige variabler for eks. Stor flamme = mindre speed
    public enum playerLvL { lvl1, lvl2, lvl3, lvl4, lvl5 };
    public playerLvL state;

    // Start is called before the first frame update
    void Start()
    {
        state = playerLvL.lvl1;

    }

    // Update is called once per frame
    void Update()
    {
        if(CollideScript.fuel == 5)
        {
            state = playerLvL.lvl2;
        }

      
    }

    
}
