using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScript : MonoBehaviour
{
    [SerializeField] private Vector3 sizeIncrease;

    public BoxCollider boxCol;
    public SpriteRenderer sr;
    public GameObject stage2;

    public static int fuel;

    void Start()
    {
        fuel = 0;
    }
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Consumable"))
        {
            fuel++;
            //Increases the scale/size of flame with a given vector3 value
            this.gameObject.transform.localScale = this.gameObject.transform.localScale + sizeIncrease;
            Debug.Log(fuel);
            //other.gameObject.SetActive(false);
        }
        //Can consume bigger items as Player State rises
        if (other.collider.CompareTag("MediumConsumable") && PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            fuel++;
            other.gameObject.SetActive(false);
        }
            
        if (fuel == 5)
        {
            PlayerStates.state = PlayerStates.playerLvL.lvl2;
            Debug.Log(PlayerStates.state);
        }
        
    }
    
}
