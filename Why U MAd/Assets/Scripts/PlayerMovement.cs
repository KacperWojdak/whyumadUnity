using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed = 3f;
    public Transform playerTransform;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;
        playerTransform.position += moveSpeed * Time.deltaTime * moveDirection;
    }
}
