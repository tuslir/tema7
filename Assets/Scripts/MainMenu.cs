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
    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void SettingsMenu()
    {
        settings.enabled = true;
        mainMenu.enabled = false;
    }

    public void MainMenuScreen()
    {
        mainMenu.enabled = true;
        settings.enabled = false;
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void MuteButton()
    {
        muteButton.SetActive(false);
        unMuteButton.SetActive(true);
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().mute = true;
    }

    public void UnMuteButton()
    {
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
