using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScript : MonoBehaviour
{
    [SerializeField] private Vector3 sizeIncrease;
    
    
    public SpriteRenderer sr;
    public GameObject stage2;

    public static int fuel;

    void Start()
    {
        fuel = 0;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Consumable")
        {
            fuel++;
            //Increases the scale/size of flame with a given vector 3 value
            this.gameObject.transform.localScale = this.gameObject.transform.localScale + sizeIncrease;
            //Destroy(other);
        }

        if (other.tag == "MidConsumable" && PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            fuel++;
            //Increases the scale/size of flame with a given vector 3 value
            this.gameObject.transform.localScale = this.gameObject.transform.localScale + sizeIncrease;
            //Destroy(other);
        }

        if (fuel == 5)
        {
            //stage2.SetActive(true);
        }

    }
    
}
