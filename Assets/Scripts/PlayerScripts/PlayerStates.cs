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
    public static bool canWin = false;
    public int pointsTo2, pointsTo3;

    // Start is called before the first frame update
    void Start()
    {
        state = playerLvL.lvl1;
    }

    // Update is called once per frame
    void Update()
    {
      
        //Changes player to next Lvl
        if(CollideScript.fuel == pointsTo2)
        {
            state = playerLvL.lvl2;
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0.7660803f, -1.312147f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(2.75416f, 6.098046f);
            print(state);
            //text.text = "LVL2";
        }

        if (CollideScript.fuel <= pointsTo2)
        {
            state = playerLvL.lvl1;
            /*this.GetComponent<BoxCollider2D>().offset = new Vector2(-0.08181202f, -0.2603035f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(2.254308f, 2.426708f);*/
            //text.text = "LVL1";
        }

        if (CollideScript.fuel == pointsTo3)
        {
            state = playerLvL.lvl3;
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0.8f, -7f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(8f, 2.5f);
            print(state);
        }

        if (CollideScript.fuel <= pointsTo3-1 && CollideScript.fuel >= pointsTo2)
        {
            state = playerLvL.lvl2;
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0.7f, -3.2f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(2.6f, 2.4f);
        }

        if(CollideScript.fuel == 100 && state == playerLvL.lvl3)

        {

            canWin = true;

        }


        
    }

    
}
