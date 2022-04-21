using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private void Update()
    {
        if (VideoManager.VP.clip && Input.GetKeyDown(KeyCode.Escape) || VideoManager.timeToStopIntro <= 0)
        {
            LoadLevel();
            return;
        }
        
    }

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("PlayButton");
        SceneManager.LoadScene(1);
    }

    public void QuitToMain()
    {
        FindObjectOfType<AudioManager>().Play("PlayButton");
        SceneManager.LoadScene(0);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(2);
    }

    public static void LoadOutro()
    {
        SceneManager.LoadScene(3);
    }
    public static void LoadMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
