using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelectionController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel;

    public TextMeshProUGUI[] bestDeathCountsTexts;
    public TextMeshProUGUI[] bestTimesTexts;

    private int[] bestDeaths;
    private float[] bestTimes;

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
        bestTimes = new float[levelCount];

        for (int i = 0; i < levelCount; i++)
        {
            bestDeaths[i] = PlayerPrefs.GetInt($"Level{i + 1}_BestDeaths", int.MaxValue);

            string bestTimeStr = PlayerPrefs.GetString($"Level{i + 1}_BestTime", "N/A");
            if (!float.TryParse(bestTimeStr, out bestTimes[i]))
                bestTimes[i] = float.MaxValue;

            Debug.Log($"Retrieved best time for Level {i + 1}: {bestTimes[i]} (raw string: '{bestTimeStr}')");
        }
    }


    private void UpdateLevelStatsUI()
    {
        for (int i = 0; i < bestDeathCountsTexts.Length; i++)
        {
            if (bestDeaths[i] != int.MaxValue && bestTimes[i] != float.MaxValue)
            {
                bestDeathCountsTexts[i].text = $"{bestDeaths[i]}";
                bestTimesTexts[i].text = $"{bestTimes[i]:F2}s";
            }
            else
                bestDeathCountsTexts[i].text = "";
                bestTimesTexts[i].text = "";
        }
    }

    public void LoadLevel(int levelIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene($"Level{levelIndex}");
    }
}
