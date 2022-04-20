using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer VP;
    [SerializeField] private RawImage video;
    private float timeToStop;

    // Start is called before the first frame update
    void Start()
    {
        VP = GetComponent<VideoPlayer>();
        timeToStop = 56f;
    }

    // Update is called once per frame
    void Update()
    {
        if(VP.clip)
        {
            FindObjectOfType<AudioManager>().Stop("MainMenu");
        }

        timeToStop -= Time.deltaTime;

        if(timeToStop <=0)
        {
            video.enabled = false;
            Debug.Log("Video Finsihed");
            FindObjectOfType<AudioManager>().Play("Flamey_footsteps1.8");
            Destroy(this);
        }
        
    }
}
