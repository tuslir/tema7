using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //Direction Input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        if (x < 0)
        {
            sr.flipX = false;
        }
        else if (x > 0)
        {
            sr.flipX = true;
        }

        anim.SetBool("isDashing", DashScript.isDashing);

        if(DashScript.isDashing && PlayerStates.state == PlayerStates.playerLvL.lvl1)
        {
            anim.SetBool("isDashing", DashScript.isDashing);
            anim.Play("DashV1");
        }

        if (DashScript.isDashing && PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            anim.SetBool("isDashing", DashScript.isDashing);
            anim.Play("DashV2");

        }



    }
}
