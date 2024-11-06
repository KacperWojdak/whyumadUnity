using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            transform.position = spawnPoint.position;
        }
    }
}
