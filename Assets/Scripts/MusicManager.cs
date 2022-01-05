using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioClip[] gameMusic;

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

    public void PlayGameMusic()
    {
        audioSource.clip = gameMusic[1]; // Game Music [1]
        audioSource.volume = 0.4f;
        audioSource.Play();
    }

    public void PlayMenuMusic()
    {
        audioSource.clip = gameMusic[0]; // Menu Music [0]
        audioSource.volume = 0.4f;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}