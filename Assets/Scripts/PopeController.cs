using UnityEngine;

public class PopeController : MonoBehaviour
{
    public static PopeController instance;
    public float moveSpeed = 1f;
    public GameObject kremowkaCollectedEffect;
    public AudioClip kremowkaCollected;
    public GameObject[] skins;

    private AudioSource audioSource;
    private bool isLeft = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        LoadSkinOnStartup();
        ChangeDirection();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckDirection();
        }

        // Player fell off the platforms
        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
    }

    private void CheckDirection()
    {
        if (Input.GetMouseButtonDown(0) && transform.position.y >= 1)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (isLeft)
        {
            transform.rotation = Quaternion.Euler(0, 270f, 0);
            isLeft = false;
        }

        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            isLeft = true;
        }
    }

    private void Move()
    {
        //transform.position += transform.forward * -moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
    }

    private void LoadSkinOnStartup()
    {
        string savedSkinName;

        // save current skin name to player prefs
        if (PlayerPrefs.HasKey("currentSkinName"))
        {
            savedSkinName = PlayerPrefs.GetString("currentSkinName");
        }
        else
        {
            // Player has not chosen any skin (first play, load default skin)
            PlayerPrefs.SetString("currentSkinName", "skinID1");
            savedSkinName = "skinID1";
        }

        foreach (GameObject skin in skins)
        {
            if (skin.name == savedSkinName)
            {
                ChangeSkin(skin);
            }

        }
    }

    public void ChangeSkin(GameObject skinModel)
    {
        // delete all previous skins
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        // instantiate new skin and set it as a parent
        GameObject skinInstance = Instantiate(skinModel, transform.position, transform.rotation);
        skinInstance.transform.SetParent(gameObject.transform);

        // save current skin name to player prefs
        PlayerPrefs.SetString("currentSkinName", skinModel.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kremowka")
        {
            PlayKremowkaCollected();
            ScoreManager.instance.KremowkaCollected(1);

            Instantiate(kremowkaCollectedEffect, other.transform.position, kremowkaCollectedEffect.transform.rotation); ;

            other.gameObject.SetActive(false);
        }
    }

    public void PlayKremowkaCollected()
    {
        audioSource.clip = kremowkaCollected;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
}