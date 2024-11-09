using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject creditsPanel;
    public GameObject levelSelectionPanel;
    public GameObject mainMenuPanel;
    public Slider volumeSlider;
    private GlobalAudioManager globalAudioManager;

    void Start()
    {
        globalAudioManager = Object.FindFirstObjectByType<GlobalAudioManager>();

        if (volumeSlider != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("GlobalVolume", 1f);
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        levelSelectionPanel.SetActive(false);
    }

    public void OpenLevels()
    {
        levelSelectionPanel.SetActive(true);
    }

    public void CloseLevels()
    {
        levelSelectionPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        if (globalAudioManager != null)
            globalAudioManager.SetVolume(volume);
    }
}
