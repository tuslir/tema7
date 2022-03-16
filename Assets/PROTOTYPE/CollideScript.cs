using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScript : MonoBehaviour
{

    public SpriteRenderer sr;
    public GameObject stage2;

    public int fuel;

    void Start()
    {
        fuel = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Consumable")
        {
            fuel++;
            Destroy(other);
        }

        if (fuel == 2)
        {
            stage2.SetActive(true);
        }
    }

}
