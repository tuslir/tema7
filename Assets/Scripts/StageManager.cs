using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
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


    public void ExitGame()
    {
        Application.Quit();
    }
}
