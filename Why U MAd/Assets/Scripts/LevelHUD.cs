using UnityEngine;
using TMPro;

public class LevelHUD : MonoBehaviour
{
    public TextMeshProUGUI deathCounterText;
    public TextMeshProUGUI timerText;
    private int deathCount = 0;
    private float levelStartTime;
    private bool levelFinished = false;
    private bool timerStarted = false;

    void Start()
    {
        UpdateDeathCounter();
        timerText.text = "0.00s";
    }

    void Update()
    {
        if (timerStarted && !levelFinished)
        {
            float currentTime = Time.time - levelStartTime;
            timerText.text = currentTime.ToString("F2") + "s";
        }
    }

    public void StartTimer()
    {
        if (!timerStarted)
        {
            timerStarted = true;
            levelStartTime = Time.time;
        }
    }

    public void IncrementDeathCounter()
    {
        deathCount++;
        UpdateDeathCounter();
    }

    private void UpdateDeathCounter()
    {
        deathCounterText.text = "" + deathCount;
    }

    public void MarkLevelAsFinished()
    {
        levelFinished = true;
    }

    public int GetDeathCount()
    {
        return deathCount;
    }

    public float GetFinalTime()
    {
        float currentTime = Time.time - levelStartTime;
        return currentTime;
    }
}
