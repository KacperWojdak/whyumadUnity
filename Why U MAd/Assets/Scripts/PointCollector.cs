using UnityEngine;

public class PointCollector : MonoBehaviour
{
    public int pointsCollected = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            pointsCollected++;
            collision.gameObject.SetActive(false);
        }
    }
}
