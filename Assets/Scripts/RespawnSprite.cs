using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSprite : MonoBehaviour
{

    BoxCollider boxCollide; 
    public GameObject player;
    Animator anim;

    //public float coolDown;      //the amount of time the timer should count down.
    //public float growTimer;     //timer for how long it takes the sprite to grow back.

    public float range;         //range from player before item grows back.

    void Start()
    {
        boxCollide = GetComponentInChildren<BoxCollider>();
        anim = GetComponentInChildren<Animator>();
        //growTimer = coolDown;
    }

    void Update()
    {

        //growTimer -= Time.deltaTime;

        float dist = Vector3.Distance(player.transform.position, boxCollide.transform.position);

        if (dist > range)
        {
            ResetSprite();
            print("reset!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BurnDown();
            print("burned!");
        }
    }

    void BurnDown()
    {
        anim.ResetTrigger("growBack");
        anim.SetTrigger("burnt");



        //changes sprite to burnt
    }

    void ResetSprite()
    {
        anim.ResetTrigger("burnt");
        anim.SetTrigger("growBack");


        //resets sprite
    }

}
