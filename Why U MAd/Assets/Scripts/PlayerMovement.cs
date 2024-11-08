using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform playerTransform;
    private LevelHUD levelHUD;

    void Start()
    {
        levelHUD = Object.FindFirstObjectByType<LevelHUD>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;

        if ((moveX != 0 || moveY != 0) && levelHUD != null)
            levelHUD.StartTimer();

        playerTransform.position += moveSpeed * Time.deltaTime * moveDirection;
    }
}
