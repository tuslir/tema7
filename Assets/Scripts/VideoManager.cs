using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    public static VideoPlayer VP;
    [SerializeField] private GameObject video;
    [SerializeField] private Canvas introUI;
    [SerializeField] private VideoClip intro;
    [SerializeField] private Canvas OutroUI;
    [SerializeField] private VideoClip outro;
    public static float timeToStopIntro;
    public static float timeToStopOutro;

    // Start is called before the first frame update
    void Start()
    {
        VP = GetComponent<VideoPlayer>();
        timeToStopIntro = 56f;
        timeToStopOutro = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        if(VP.clip = intro)
        {

        timeToStopIntro -= Time.deltaTime;
        if(VP.clip && Input.GetKeyDown(KeyCode.Escape) || timeToStopIntro <=0)
        {
            //introUI.enabled = false;
            //video.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Theme");
        }

        if (VP.clip)
        {
            FindObjectOfType<AudioManager>().Stop("MainMenu");

        }
        }

        if(VP.clip = outro)
        {
            timeToStopOutro -= Time.deltaTime;
            if (VP.clip && Input.GetKeyDown(KeyCode.Escape) || timeToStopOutro <= 0)
            {
                StageManager.LoadMain();
            }
        }

    }
}
