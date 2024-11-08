using UnityEngine;

public class Finish : MonoBehaviour
{
    public int requiredPoints;
    private PointCollector pointCollector;
    private LevelHUD levelHUD;
    private LevelCompleteController levelCompleteController;
    private Collider2D finishCollider;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            pointCollector = player.GetComponent<PointCollector>();
        }

        levelHUD = Object.FindFirstObjectByType<LevelHUD>();
        levelCompleteController = Object.FindFirstObjectByType<LevelCompleteController>();
        finishCollider = GetComponent<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider2D playerCollider = collision.GetComponent<Collider2D>();

            if (finishCollider.bounds.Contains(playerCollider.bounds.min) &&
                finishCollider.bounds.Contains(playerCollider.bounds.max))
            {
                if (pointCollector != null && pointCollector.pointsCollected >= requiredPoints)
                {
                    if (levelHUD != null)
                        levelHUD.MarkLevelAsFinished();

                    if (levelCompleteController != null)
                        levelCompleteController.ShowLevelComplete();
                }
            }
        }
    }
}
