using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    public static VideoPlayer VP;
    [SerializeField] private VideoClip Intro;
    public static float timeToStopIntro;

    // Start is called before the first frame update
    void Start()
    {
        VP = GetComponent<VideoPlayer>();
        timeToStopIntro = 56f;
    }

    // Update is called once per frame
    void Update()
    {
        if(VP.clip)
        {
            Cursor.lockState = CursorLockMode.Locked;
        timeToStopIntro -= Time.deltaTime;
        if(VP.clip && Input.GetKeyDown(KeyCode.Escape) || timeToStopIntro <=0)
        {
                Cursor.lockState = CursorLockMode.None;
                //introUI.enabled = false;
                //video.SetActive(false);
                StageManager.LoadLevel();
            FindObjectOfType<AudioManager>().Play("Theme");
        }

        if (VP.clip)
        {
            FindObjectOfType<AudioManager>().Stop("MainMenu");

        }
        }
        
    }
}
