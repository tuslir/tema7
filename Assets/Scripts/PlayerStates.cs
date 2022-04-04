using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{
    //Test!! Vil vi ha med states spilleren kommer i som gir han forskjellige variabler for eks. Stor flamme = mindre speed
    public enum playerLvL { lvl1, lvl2, lvl3, lvl4, lvl5 };
    public static playerLvL state;
    public GameObject state1, state2;
    public bool small, medium, large;

    // Start is called before the first frame update
    void Start()
    {
        state = playerLvL.lvl1;
        small = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Changes player to next Lvl
        if(CollideScript.fuel == 5)
        {
            state = playerLvL.lvl2;
            small = false;
            medium = true;
            state1.SetActive(false);
            state2.SetActive(true);
            print(state);
        }

        if (CollideScript.fuel <= 4)
        {
            state = playerLvL.lvl1;
            small = true;
            medium = false;
            state2.SetActive(false);
            state1.SetActive(true);
        }

    }

    void Small()
    {
        if(medium)
        {

        }

    }

    void Medium()
    {
        if (small)
        {

        }

    }

    void Large()
    {

    }

    
}
