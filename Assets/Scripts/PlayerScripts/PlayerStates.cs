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
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0.7660803f, -1.312147f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(2.75416f, 6.098046f);
            print(state);
            //text.text = "LVL2";
        }

        if (CollideScript.fuel <= 4)
        {
            state = playerLvL.lvl1;
            this.GetComponent<BoxCollider2D>().offset = new Vector2(-0.08181202f, -0.2603035f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(2.254308f, 2.426708f);
            //text.text = "LVL1";
        }

        if (CollideScript.fuel == 10)
        {
            state = playerLvL.lvl3;
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0.2315373f, -1.522146f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(9.015943f, 14.078f);
            print(state);
        }

        if (CollideScript.fuel <= 9 && CollideScript.fuel >= 5)
        {
            state = playerLvL.lvl2;
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0.7660803f, -1.312147f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(2.75416f, 6.098046f);
        }
        
    }

    
}
