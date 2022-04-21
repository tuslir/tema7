using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
   

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("PlayButton");

        SceneManager.LoadSceneAsync(1);
    }

    public void QuitToMain()
    {
        FindObjectOfType<AudioManager>().Play("PlayButton");
        SceneManager.LoadScene(0);
    }

    public static void LoadLevel()
    {
        SceneManager.LoadScene(2);
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public static void LoadOutro()
    {
        SceneManager.LoadScene(3);
    }
    public static void LoadMain()
    {
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("MainMenu");
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
