using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed = 10f; // Rotation speed, adjustable in the Unity Editor
    // Update is called once per frame
    void Update()
    {
        // Rotate the sphere around its up axis at the specified speed
        transform.Rotate(Vector3.down, (speed * 100) * Time.deltaTime);
    }
}
