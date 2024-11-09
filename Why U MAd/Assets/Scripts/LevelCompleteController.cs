using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public GameObject completePanel;
    public TextMeshProUGUI deathCountText;
    public GameObject levelHUD;
    private LevelHUD levelHUDScript;

    void Start()
    {
        completePanel.SetActive(false);
        levelHUDScript = levelHUD.GetComponent<LevelHUD>();
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
            SceneManager.LoadScene("MainMenu");
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowLevelComplete()
    {
        Time.timeScale = 0f;
        completePanel.SetActive(true);

        if (levelHUDScript != null)
        {
            int deathCount = levelHUDScript.GetDeathCount();
            deathCountText.text = "" + deathCount;

            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

            int bestDeaths = PlayerPrefs.GetInt($"Level{currentLevelIndex}_BestDeaths", int.MaxValue);

            if (deathCount < bestDeaths)
                PlayerPrefs.SetInt($"Level{currentLevelIndex}_BestDeaths", deathCount);

            PlayerPrefs.SetInt($"Level{currentLevelIndex}_Deaths", deathCount);
            PlayerPrefs.Save();
        }

        if (levelHUD != null)
            levelHUD.SetActive(false);
    }
}
