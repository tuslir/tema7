using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TextMeshProUGUI volumeTextUI = null;
    [SerializeField] private Canvas settings;
    [SerializeField] private Canvas mainMenu;
    [SerializeField] private GameObject muteButton;
    [SerializeField] private GameObject unMuteButton;
    [SerializeField] private GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
        FindObjectOfType<AudioManager>().Play("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void SettingsMenu()
    {
        FindObjectOfType<AudioManager>().Play("NormalButton");
        settings.enabled = true;
        mainMenu.enabled = false;
    }

    public void SettingsMenuInGame()
    {
        FindObjectOfType<AudioManager>().Play("NormalButton");
        settings.enabled = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }

    public void BackToPause()
    {
        FindObjectOfType<AudioManager>().Play("NormalButton");
        settings.enabled = false;
    }

    public void MainMenuScreen()
    {
        FindObjectOfType<AudioManager>().Play("NormalButton");
        mainMenu.enabled = true;
        settings.enabled = false;
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
        Debug.Log(volume);
    }

    public void SaveVolumeButton()
    {
        FindObjectOfType<AudioManager>().Play("NormalButton");
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void MuteButton()
    {
        FindObjectOfType<AudioManager>().Play("NormalButton");
        muteButton.SetActive(false);
        unMuteButton.SetActive(true);
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().mute = true;
    }

    public void UnMuteButton()
    {
        FindObjectOfType<AudioManager>().Play("NormalButton");
        muteButton.SetActive(true);
        unMuteButton.SetActive(false);
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().mute = false;
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        AudioListener.volume = volumeValue;
    }

}
