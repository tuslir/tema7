using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] public static Animator anim;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("horizontal",player.GetComponent<Rigidbody2D>().velocity.x);
        anim.SetFloat("vertical", player.GetComponent<Rigidbody2D>().velocity.y);

        if (player.GetComponent<Rigidbody2D>().velocity.x == 0f && player.GetComponent<Rigidbody2D>().velocity.y == 0f)
        {
            anim.SetBool("isIdle", true);
        }
        else anim.SetBool("isIdle", false);
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

        anim.SetBool("isCrashing", CollideScript.isCrashing);
        anim.SetBool("isDashing", PlayerMovement.isDashing);

        if (PlayerStates.state == PlayerStates.playerLvL.lvl1)
        {
            anim.SetBool("PlayerLvl2", false);
            anim.SetBool("PlayerLvl3", false);
        }

        if (PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            anim.SetBool("PlayerLvl2", true);
            anim.SetBool("PlayerLvl3", false);
        }

        if (PlayerStates.state == PlayerStates.playerLvL.lvl3)
        {
            anim.SetBool("PlayerLvl2", false);
            anim.SetBool("PlayerLvl3", true);
        }

        if (PlayerMovement.isDashing && PlayerStates.state == PlayerStates.playerLvL.lvl1)
        {
            anim.SetBool("isDashing", DashScript.isDashing);
            anim.Play("DashV1");
        }

        if (PlayerMovement.isDashing && PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            anim.SetBool("isDashing", DashScript.isDashing);
            anim.Play("DashV2");

        }

        if (PlayerMovement.isDashing && PlayerStates.state == PlayerStates.playerLvL.lvl3)
        {
            anim.SetBool("isDashing", DashScript.isDashing);
            anim.Play("DashV3");

        }


    }

    public static void Crash()
    {
        anim.Play("CrashV1");
    }



}
