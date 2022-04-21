using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class OutroManager : MonoBehaviour
{
    public static VideoPlayer VP;
    [SerializeField] private VideoClip outro;
    public static float timeToStopOutro;

    // Start is called before the first frame update
    void Start()
    {
        VP = GetComponent<VideoPlayer>();
        
        timeToStopOutro = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        if(VP.clip = outro)
        {
            timeToStopOutro -= Time.deltaTime;
            Cursor.lockState = CursorLockMode.Locked;
            if (VP.clip && Input.GetKeyDown(KeyCode.Escape) || timeToStopOutro <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                StageManager.LoadMain();
            }
        }

    }
}
