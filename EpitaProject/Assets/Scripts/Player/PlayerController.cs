using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject losePanel;
    public GameObject loseTextObject;
    private int count;
    [SerializeField] private float speed = 10f; // Rotation speed, adjustable in the Unity Editor

    void Start()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        losePanel.SetActive(false);
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the sphere around its up axis at the specified speed
        transform.Rotate(Vector3.down, (speed * 100) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
