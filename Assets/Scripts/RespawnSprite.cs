using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSprite : MonoBehaviour
{

    BoxCollider boxCollide; 
    public GameObject player;
    Animator anim;
    public bool isBurnt;

    public float coolDown;      //the amount of time the timer should count down.
    public float growTimer;     //timer for how long it takes the sprite to grow back.

    public float range;         //range from player before item grows back.

    void Start()
    {
        boxCollide = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        growTimer -= Time.deltaTime;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > range || growTimer==0 && isBurnt)
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
        growTimer = coolDown;
        isBurnt = true;
        anim.ResetTrigger("growBack");
        anim.SetTrigger("burnt");



        //changes sprite to burnt
    }

    void ResetSprite()
    {
        isBurnt = false;
        anim.ResetTrigger("burnt");
        anim.SetTrigger("growBack");


        //resets sprite
    }

}
