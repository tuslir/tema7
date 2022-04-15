using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField] int numberOfProjectile;
    [SerializeField] GameObject projectile;

    Vector2 startPoint;

    float radius, moveSpeed;
    [SerializeField] float timer;
    float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 3f;
        radius = 5f;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            startPoint = this.transform.position;
            SpawnProjectiles(numberOfProjectile);
            timer = 0f;
        }
    }

    void SpawnProjectiles(int numberOfProjectile)
    {
        float angleStep = 360f / numberOfProjectile;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectile - 1; i++)
        {
            float projectileDirXPos = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPos = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPos, projectileDirYPos);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

            var proj = Instantiate(projectile, startPoint, Quaternion.identity);
            proj.GetComponent<Rigidbody>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;

            Destroy(proj, 4);
        }
    }

}
