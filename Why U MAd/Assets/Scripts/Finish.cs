using UnityEngine;

public class Finish : MonoBehaviour
{
    public int requiredPoints;
    private PointCollector pointCollector;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            pointCollector = player.GetComponent<PointCollector>();

        if (pointCollector == null)
            Debug.LogError("Nie znaleziono skryptu PointCollector na obiekcie gracza.");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pointCollector != null && pointCollector.pointsCollected >= requiredPoints)
                Debug.Log("Gracz zebra� wymagan� ilo�� punkt�w. Poziom uko�czony!");
            else
                Debug.Log("Gracz nie zebra� wymaganej ilo�ci punkt�w.");
        }
    }
}
