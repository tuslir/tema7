using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer VP;
    [SerializeField] private GameObject video;
    [SerializeField] private Canvas introUI;
    [SerializeField] private GameObject fadeIn;
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
        timeToStop -= Time.deltaTime;
        if(VP.clip && Input.GetKeyDown(KeyCode.Escape) || timeToStop <=0)
        {
            introUI.enabled = false;
            video.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Theme");
        }

        if (VP.clip)
        {
            fadeIn.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("MainMenu");

        }

    }
}
