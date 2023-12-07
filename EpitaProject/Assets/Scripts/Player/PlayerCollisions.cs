using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private GameObject bloodParticles;
    private Animator playerAnim;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject Panel;
    public GameObject loseTextObject;
    
    public GameObject[] emptyBottles;
    public GameObject[] fullBottles;

    private int countBottle = 0;

    private int count;

    void Start()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        Panel.SetActive(false);
        loseTextObject.SetActive(false);
        emptyBottles[countBottle].SetActive(true);
        fullBottles[countBottle].SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        bloodParticles.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Size")
        {
            GameEvents.instance.playerSize.Value += 1;
            other.GetComponent<Collider>().enabled = false;
            other.transform.DOScale(Vector3.zero, 0.5f).OnComplete(()=>
            {
                Destroy(other.gameObject);
            });
        }

        if (other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.tag == "Obstacle")
        {
            playerAnim.SetTrigger("kick");
            other.GetComponent<Block>().CheckHit();
        }
        if (other.tag == "Gate")
            other.GetComponent<Gate>().ExecuteOperation();
        if (other.tag == "Saw")
        {
            GameEvents.instance.gameLost.SetValueAndForceNotify(true);
            bloodParticles.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }
        if (other.tag == "Finish")
        {
            GameEvents.instance.gameWon.SetValueAndForceNotify(true);
            winTextObject.SetActive(true);
            Panel.SetActive(true);
        }
        if (other.CompareTag("Bottle") && countBottle < emptyBottles.Length)
        {
            other.gameObject.SetActive(false);
            emptyBottles[countBottle].SetActive(false);
            fullBottles[countBottle].SetActive(true);
            countBottle++;
        }
    }

}