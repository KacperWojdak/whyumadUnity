using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform enemySpawnPoint;
    public float moveSpeed = 2f;
    private bool isPlayerInSafeZone = false;

    void Update()
    {
        if (!isPlayerInSafeZone)
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            transform.position = enemySpawnPoint.position;
    }

    public void ResetEnemyPosition()
    {
        transform.position = enemySpawnPoint.position;
    }

    public void StopMoving()
    {
        isPlayerInSafeZone = true;
    }

    public void ResumeMoving()
    {
        isPlayerInSafeZone = false;
    }
}
