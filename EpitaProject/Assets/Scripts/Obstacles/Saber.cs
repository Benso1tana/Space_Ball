using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [SerializeField] private float speed = 10f; // Rotation speed, adjustable in the Unity Editor
    // Update is called once per frame
    void Update()
    {
        // Rotate the sphere around its up axis at the specified speed
        transform.Rotate(Vector3.up, (speed * 100) * Time.deltaTime);
    }
}
