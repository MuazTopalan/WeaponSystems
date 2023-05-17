using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public GameObject ground;
    private Vector3 randomPosition;

    [SerializeField] private float speed = 1.0f;

    private void Start()
    {
        randomPosition = ground.transform.position + new Vector3(Random.Range(-15.0f, 15.0f), 0, Random.Range(-15.0f, 15.0f));
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, randomPosition, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, randomPosition) < 0.1f)
        {
            randomPosition = ground.transform.position + new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-15.0f, 15.0f));
        }
    }
}
