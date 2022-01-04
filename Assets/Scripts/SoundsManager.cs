using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;

    public AudioClip click;
    public AudioClip stoneBreak;

    private AudioSource audioSource;

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
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PlayClick()
    {
        audioSource.clip = click;
        audioSource.volume = 1f;
        audioSource.Play();
    }

    public void PlayStoneBreak()
    {
        audioSource.clip = stoneBreak;
        audioSource.volume = 0.1f;

        // Generate random pitch of breaking stone
        float rand = Random.Range(0.5f, 2.5f);
        audioSource.pitch = rand; 

        audioSource.Play();
    }
}