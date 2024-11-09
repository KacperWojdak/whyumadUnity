using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform enemySpawnPoint;
    public float moveSpeed = 2f;
    private float initialMoveSpeed;
    private bool isPlayerInSafeZone = false;

    void Start()
    {
        initialMoveSpeed = moveSpeed;
        InvokeRepeating(nameof(IncreaseSpeed), 1f, 1f);
    }

    void Update()
    {
        if (!isPlayerInSafeZone)
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = enemySpawnPoint.position;
            ResetSpeed();
        }
    }

    public void ResetEnemyPosition()
    {
        transform.position = enemySpawnPoint.position;
        ResetSpeed();
    }

    public void StopMoving()
    {
        isPlayerInSafeZone = true;
    }

    public void ResumeMoving()
    {
        isPlayerInSafeZone = false;
    }

    private void IncreaseSpeed()
    {
        moveSpeed += 0.05f;
    }

    private void ResetSpeed()
    {
        moveSpeed = initialMoveSpeed;
    }
}
