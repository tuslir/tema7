using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{
    //Test!! Vil vi ha med states spilleren kommer i som gir han forskjellige variabler for eks. Stor flamme = mindre speed
    public enum playerLvL { lvl1, lvl2, lvl3, lvl4, lvl5 };
    public static playerLvL state;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        state = playerLvL.lvl1;
    }

    // Update is called once per frame
    void Update()
    {
      
        //Changes player to next Lvl
        if(CollideScript.fuel == 5)
        {
            state = playerLvL.lvl2;
            print(state);
            //text.text = "LVL2";
        }

        if (CollideScript.fuel <= 4)
        {
            state = playerLvL.lvl1;
            //text.text = "LVL1";
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
