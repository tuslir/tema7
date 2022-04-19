using UnityEngine;

public class FootPrints : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private GameObject footPrints;
    [SerializeField] private ObjectPooling pooling;
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
            footPrints.transform.position = this.transform.position;
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
