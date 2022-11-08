using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    float startingZPosition;
    [SerializeField] float _reset = 10f;

    void Start() => startingZPosition = transform.position.z;

    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * moveSpeed;
        if (transform.position.z <= -_reset)
        {
            transform.position += Vector3.back * 30f;
            float newY = Random.Range(-3, 3);
            transform.position = new Vector3(transform.position.x, newY, startingZPosition);
        }
    }
}