using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelectionController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel;

    public TextMeshProUGUI[] bestDeathCountsTexts;

    private int[] bestDeaths;

    void Start()
    {
        levelSelectionPanel.SetActive(false);
        LoadLevelStats();
        UpdateLevelStatsUI();
    }

    public void ShowLevelSelection()
    {
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        levelSelectionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    private void LoadLevelStats()
    {
        int levelCount = bestDeathCountsTexts.Length;
        bestDeaths = new int[levelCount];

        for (int i = 0; i < levelCount; i++)
            bestDeaths[i] = PlayerPrefs.GetInt($"Level{i + 1}_BestDeaths", int.MaxValue);
    }

    private void UpdateLevelStatsUI()
    {
        for (int i = 0; i < bestDeathCountsTexts.Length; i++)
        {
            if (bestDeaths[i] != int.MaxValue)
                bestDeathCountsTexts[i].text = $"{bestDeaths[i]}";
            else
                bestDeathCountsTexts[i].text = "";
        }
    }

    public void LoadLevel(int levelIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene($"Level{levelIndex}");
    }
}
