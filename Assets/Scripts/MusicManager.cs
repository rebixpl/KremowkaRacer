using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

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
        audioSource.clip = gameMusic;
        audioSource.volume = 0.4f;
        audioSource.Play();
    }

    public void PlayMenuMusic()
    {
        audioSource.clip = menuMusic;
        audioSource.volume = 0.4f;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}