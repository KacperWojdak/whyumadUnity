using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    public Vector3 newScale;
    public float newMoveSpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.localScale = newScale;

            if (other.TryGetComponent<PlayerMovement>(out var playerMovement))
                playerMovement.moveSpeed = newMoveSpeed;
        }
    }
}
