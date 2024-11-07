using UnityEngine;

public class ObjectWallBounce : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 moveDirection;

    void Start()
    {
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad), 0).normalized;
    }

    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * moveDirection;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            moveDirection = Vector3.Reflect(moveDirection, collision.contacts[0].normal);
    }
}
