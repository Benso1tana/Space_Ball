using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.5f; 
    [SerializeField] private float frequency = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPosition.y + amplitude * Mathf.Sin(frequency * Time.time);

        // Update the position of the object
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
