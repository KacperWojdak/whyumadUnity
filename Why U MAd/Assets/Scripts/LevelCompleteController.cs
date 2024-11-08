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

    public void ShowLevelComplete()
    {
        Time.timeScale = 0f;
        completePanel.SetActive(true);

        if (levelHUDScript != null)
        {
            deathCountText.text = "" + levelHUDScript.GetDeathCount();
            timeText.text = levelHUDScript.GetFinalTime() + "s";
        }

        if (levelHUD != null)
        {
            levelHUD.SetActive(false);
        }
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
}
