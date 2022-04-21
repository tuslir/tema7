using UnityEngine;

public class CollideScript : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Vector3 sizeIncrease;
    [SerializeField] private Vector3 sizeDecrease;
    [SerializeField] private Vector3 camZoom;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    public static int fuel;
    public static bool isCrashing;
    RespawnSprite respawn;
    bool maxCam;

    void Start()
    {
        fuel = 0;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        respawn = other.gameObject.GetComponent<RespawnSprite>();


        if (other.CompareTag("Consumable"))
        {

            fuel++;
            //Increases the scale/size of flame with a given vector 3 value
            FindObjectOfType<AudioManager>().Play("Flamey_Burn3");
            this.gameObject.transform.localScale = this.gameObject.transform.localScale + sizeIncrease;
            cam.transform.position -= camZoom;
            //Destroy(other);
            print(fuel);
            respawn.BurnDown();
        }

        if (other.CompareTag("MidConsumable") && PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            fuel++;
            //Increases the scale/size of flame with a given vector 3 value
            this.gameObject.transform.localScale = this.gameObject.transform.localScale + sizeIncrease;
            cam.transform.position -= camZoom;
            //Destroy(other);
            print(fuel);
            respawn.BurnDown();
        }

        if (other.CompareTag("Hazard")&& fuel >=1)
        {
            fuel--;
            FindObjectOfType<AudioManager>().Play("Flamey_Slukkes");
            //Shrinks Player size
            this.gameObject.transform.localScale = this.gameObject.transform.localScale - sizeDecrease;
            cam.transform.position += camZoom;
            Debug.Log(fuel);
            //Destroy(other);
        }

        if(other.CompareTag("Volcano") && PlayerStates.canWin)
        {
            StageManager.LoadOutro();
        }
        
        if (PlayerStates.state == PlayerStates.playerLvL.lvl3 && !maxCam)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, (cam.transform.position.z - 20));
            maxCam = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("MidConsumable") && PlayerStates.state == PlayerStates.playerLvL.lvl1)
        {
            isCrashing = true;
            PlayerAnimationController.Crash();
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("MidConsumable") && PlayerStates.state == PlayerStates.playerLvL.lvl1)
        {
            isCrashing = false;
        }

    }

    void LVL3Camera()
    {

    }
}
