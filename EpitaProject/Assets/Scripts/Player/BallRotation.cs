using UnityEngine;

public class BallRotation : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Rotation speed, adjustable in the Unity Editor

    // Update is called once per frame
    void Update()
    {
        // Rotate the sphere around its up axis at the specified speed
        transform.Rotate(Vector3.down, (speed * 100) * Time.deltaTime);
    }
}
