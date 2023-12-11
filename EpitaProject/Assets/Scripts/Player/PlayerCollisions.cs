using UnityEngine;
using DG.Tweening;
using TMPro;
using PathCreation.Examples;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private GameObject bloodParticles;
    private Animator playerAnim;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject Panel;
    public GameObject loseTextObject;

    public GameObject pauseButton;
    [SerializeField] GameObject pauseMenu;
    public PathFollower trackSpeed;
    public PlayerController rotationSpeed;
    private int countBottle = 0;
    public GameObject Explosion_object;
    public int threshhold = 20; 
    private int count;
    public int speedBoost = 10  ;
    public Renderer sphereRenderer;

    public ParticleSystem sphereParticles;


    void Start()
    {
        if (sphereParticles != null)
        {
            sphereParticles.Stop();
        }
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Panel.SetActive(false);
        loseTextObject.SetActive(false);
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
           if( trackSpeed.speed < threshhold)
            {
                GameEvents.instance.gameWon.SetValueAndForceNotify(true);
                loseTextObject.SetActive(true);
                pauseButton.SetActive(false);
                // Panel.SetActive(true);
                Debug.Log("Ouchs");
            }
           else
            {
                other.gameObject.SetActive(false); 
            }
           

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
            pauseButton.SetActive(false);
            // Panel.SetActive(true);
        }
        if (other.tag == "toDestroy")
        {
            other.gameObject.SetActive(false);
            Instantiate(Explosion_object, transform.position, Quaternion.identity);
        }

    
        if (other.CompareTag("Bottle"))
        {
            other.gameObject.SetActive(false);
            countBottle++;
            Debug.Log("picked bottle") ; 
             if (trackSpeed != null)
            {
                trackSpeed.speed += speedBoost;
                Debug.Log("added speed") ;
            }
            if (rotationSpeed != null)
            {
                rotationSpeed.speed += speedBoost / 5 ;
            }
            if(threshhold < trackSpeed.speed)
            if (sphereRenderer != null)
                {
                     Material sphereMaterial = sphereRenderer.material;
                    sphereMaterial.EnableKeyword("_EMISSION");

                    Color baseEmissionColor = Color.white; // Your base emission color
                    float intensityMultiplier = 0.3f; // Adjust this value for intensity (0 = no emission, 1 = full intensity)
                    Color finalEmissionColor = baseEmissionColor * intensityMultiplier;
                    sphereParticles.Play();
                    sphereMaterial.SetColor("_EmissionColor", finalEmissionColor);
                }
        }
    }

}