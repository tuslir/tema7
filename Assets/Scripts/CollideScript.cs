using UnityEngine;

public class CollideScript : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Vector3 sizeIncrease;
    [SerializeField] private Vector3 sizeDecrease;
    [SerializeField] private Vector3 camZoom;

    [SerializeField] private Camera cam;
    public static int fuel;
    RespawnSprite respawn;

    void Start()
    {
        fuel = 0;
    }

    private void OnTriggerEnter(Collider other)
    {

        respawn = other.gameObject.GetComponent<RespawnSprite>();


        if (other.tag == "Consumable")
        {

            fuel++;
            //Increases the scale/size of flame with a given vector 3 value
            this.gameObject.transform.localScale = this.gameObject.transform.localScale + sizeIncrease;
            cam.transform.position -= camZoom;
            //Destroy(other);
            print(fuel);
            respawn.BurnDown();
        }

        if (other.tag == "MidConsumable" && PlayerStates.state == PlayerStates.playerLvL.lvl2)
        {
            fuel++;
            //Increases the scale/size of flame with a given vector 3 value
            this.gameObject.transform.localScale = this.gameObject.transform.localScale + sizeIncrease;
            cam.transform.position -= camZoom;
            //Destroy(other);
            print(fuel);
            respawn.BurnDown();
        }

        if (other.tag == "Hazard")
        {
            if (fuel >= 1)
            {
                fuel--;
                //Shrinks Player size
                this.gameObject.transform.localScale = this.gameObject.transform.localScale - sizeDecrease;
                cam.transform.position += camZoom;
                Debug.Log(fuel);
            }
        }
    }

}
