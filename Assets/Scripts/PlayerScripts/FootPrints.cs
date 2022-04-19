using UnityEngine;

public class FootPrints : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private GameObject footPrints;
    [SerializeField] private ObjectPooling pooling;
    [SerializeField] private Vector3 offset2;
    [SerializeField] private Vector3 offset3;
    private float timer = 0;
    private float totalTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (pooling.objectToPool != null)
        {
            footPrints = ObjectPooling.SharedInstance.GetPooledObject();
        }
        totalTime += Time.deltaTime;
        timer += Time.deltaTime;
        if (totalTime > 0.1f)
        {
            if (PlayerStates.state == PlayerStates.playerLvL.lvl1)
            {
                footPrints.transform.position = this.transform.position -= offset2;
            }
            else if (PlayerStates.state == PlayerStates.playerLvL.lvl2)
            {
                footPrints.transform.position = this.transform.position - offset2;
            }
            else if (PlayerStates.state == PlayerStates.playerLvL.lvl3)
            {
                footPrints.transform.position = this.transform.position - offset3;
            }

            footPrints.SetActive(true);
            totalTime = 0;
        }

        if (timer > 0.1f)
        {
            footPrints = GameObject.Find("ScorchMarks(Clone)");
            footPrints.SetActive(false);
            timer = 0;
        }


    }
}
