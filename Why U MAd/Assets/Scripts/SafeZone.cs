using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private Enemy[] allEnemies;

    void Start()
    {
        allEnemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (Enemy enemy in allEnemies)
            {
                enemy.StopMoving();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (Enemy enemy in allEnemies)
                enemy.ResumeMoving();
        }
    }
}
