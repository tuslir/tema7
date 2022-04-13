using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator anim;
    private CharacterController controller;

   
    [Header("Stored Variables")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private float movementSpeed;
    public static Vector3 movementDir;
    public static Vector3 motion;
    Vector3 velocity;

    [Header("Bools")]
    private bool isPaused;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Definerer hvor animator skal hente walk parameter
        anim.SetFloat("horizontal", Mathf.Abs(motion.x));
        anim.SetFloat("vertical", Mathf.Abs(motion.y));

        //MOVEMENT WITH CHARACTER CONTROLLER
        controller.Move(velocity * Time.deltaTime);
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movementDir = transform.right * x + transform.up * y;
        motion = movementDir * movementSpeed * Time.deltaTime;
        controller.Move(motion);


        /*//PauseMenu med toggle funksjon
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }
        */

    }
}
