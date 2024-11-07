using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform enemySpawnPoint;
    public float moveSpeed = 2f;

    void Update()
    {
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
}
