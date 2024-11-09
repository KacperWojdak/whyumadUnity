using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public GameObject completePanel;
    public TextMeshProUGUI deathCountText;
    public TextMeshProUGUI timeText;
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
            float finalTime = levelHUDScript.GetFinalTime();

            deathCountText.text = "" + deathCount;
            timeText.text = finalTime.ToString("F2") + "s";

            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

            int bestDeaths = PlayerPrefs.GetInt($"Level{currentLevelIndex}_BestDeaths", int.MaxValue);
            string bestTimeStr = PlayerPrefs.GetString($"Level{currentLevelIndex}_BestTime", "N/A");

            if (!float.TryParse(bestTimeStr, out float bestTime))
            {
                bestTime = float.MaxValue;
            }

            if (deathCount < bestDeaths || (deathCount == bestDeaths && finalTime < bestTime))
            {
                PlayerPrefs.SetInt($"Level{currentLevelIndex}_BestDeaths", deathCount);
                Debug.Log($"Saving time for Level {currentLevelIndex}: {finalTime}");
                PlayerPrefs.SetString($"Level{currentLevelIndex}_BestTime", finalTime.ToString("F2"));
            }

            PlayerPrefs.SetInt($"Level{currentLevelIndex}_Deaths", deathCount);
            Debug.Log($"Saving time for Level {currentLevelIndex}: {finalTime}");
            PlayerPrefs.SetString($"Level{currentLevelIndex}_CompletionTime", finalTime.ToString("F2"));
            PlayerPrefs.Save();
        }

        if (levelHUD != null)
            levelHUD.SetActive(false);
    }

}
