using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSprite : MonoBehaviour
{

    BoxCollider boxCollide; 
    GameObject player;
    Animator anim;

    SpriteRenderer spriteRenderer;
    public Sprite originalSprite;
    public Sprite burntSprite;

    public bool isBurnt;        //makes sure anim triggers don't set if item is already "burnt".
                                //call on this in CollideScript so player won't grow when moving over things already burnt?


    [Header ("Public for debug")]
    public float coolDown;      //the amount of time until item grows back.
    public float growTimer;     //timer counting down (from coolDown float) until item grows back.
    public float range;         //distance from player before item grows back.


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollide = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();

        spriteRenderer.sprite = originalSprite;
    }

    void Update()
    {

        growTimer -= Time.deltaTime;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > range || growTimer==0 && isBurnt)        //if distance between item and player is larger than allowed range, OR the timer runs out
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
        spriteRenderer.sprite = burntSprite;


        //anim.ResetTrigger("growBack");
        //anim.SetTrigger("burnt");



        //changes sprite to burnt
    }

    void ResetSprite()
    {
        isBurnt = false;
        spriteRenderer.sprite = originalSprite;


        //anim.ResetTrigger("burnt");
        //anim.SetTrigger("growBack");


        //resets sprite
    }

}
