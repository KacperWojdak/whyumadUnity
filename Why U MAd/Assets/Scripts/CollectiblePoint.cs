using UnityEngine;

public class CollectiblePoint : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
        gameObject.SetActive(true);
    }
}
