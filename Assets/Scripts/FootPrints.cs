using UnityEngine;

public class FootPrints : MonoBehaviour
{
    [SerializeField] private float timer = 0;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float totalTime = 0;
    public ObjectPooling pooling;
    public GameObject footPrints;

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
        if (totalTime > 0.5f)
        {
            footPrints.transform.position = this.transform.position;
            footPrints.SetActive(true);
            totalTime = 0;
        }

        if (timer > 2f)
        {
            pooling.objectToPool.SetActive(false);
            timer = 0;
        }


    }
}
