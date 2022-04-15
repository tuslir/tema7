using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    //Test!! Vil vi ha med states spilleren kommer i som gir han forskjellige variabler for eks. Stor flamme = mindre speed
    public enum playerLvL { lvl1, lvl2, lvl3, lvl4, lvl5 };
    public static playerLvL state;

    // Start is called before the first frame update
    void Start()
    {
        state = playerLvL.lvl1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);
        //Changes player to next Lvl
        if(CollideScript.fuel == 5)
        {
            state = playerLvL.lvl2;
            print(state);
        }

        if (CollideScript.fuel <= 4)
        {
            state = playerLvL.lvl1;
        }

        if (CollideScript.fuel == 10)
        {
            state = playerLvL.lvl3;
            print(state);
        }

        if (CollideScript.fuel <= 9 && CollideScript.fuel >= 5)
        {
            state = playerLvL.lvl2;
        }
        
    }

    
}
