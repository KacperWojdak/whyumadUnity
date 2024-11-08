using UnityEngine;
using System.Collections.Generic;

public class PlayerReset : MonoBehaviour
{
    public Transform spawnPoint;
    private List<CollectiblePoint> allPoints;
    private List<Enemy> allEnemies;
    private PointCollector pointCollector;
    private LevelHUD levelHUD;

    void Start()
    {
        allPoints = new List<CollectiblePoint>(FindObjectsByType<CollectiblePoint>(FindObjectsSortMode.None));
        allEnemies = new List<Enemy>(FindObjectsByType<Enemy>(FindObjectsSortMode.None));
        pointCollector = GetComponent<PointCollector>();

        GameObject hud = GameObject.Find("LevelHUD");
        if (hud != null)
        {
            levelHUD = hud.GetComponent<LevelHUD>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            transform.position = spawnPoint.position;

            foreach (CollectiblePoint point in allPoints)
                point.ResetPosition();

            if (pointCollector != null)
                pointCollector.pointsCollected = 0;

            foreach (Enemy enemy in allEnemies)
                enemy.ResetEnemyPosition();

            if (levelHUD != null)
                levelHUD.IncrementDeathCounter();
        }
    }
}
