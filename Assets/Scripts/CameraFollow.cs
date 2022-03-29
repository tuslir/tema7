using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 camZoom;
    public bool fuelInc;
    public bool canZoom;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        /*
                if (CollideScript.fuelIncremented)
                {
                    CameraZoomOut();
                    canZoom = true;
                }

                if(CollideScript.fuelDecrease)
                {
                    CameraZoomIn();
                    canZoom = true;
                }
            }

            void CameraZoomIn()
            {
                transform.position += camZoom;
                canZoom = false;
            }

            void CameraZoomOut()
            {
                transform.position -= camZoom;
                canZoom = false;
            }

                */
    }
}
