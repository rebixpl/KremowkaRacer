using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted = false;

    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public GameObject menuUI;

    // Awake gets called even before Start()
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        MusicManager.instance.PlayMenuMusic();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameStarted)
        {
            // User taps on screen
            if (Input.GetMouseButtonDown(0))
            {
                SoundsManager.instance.PlayClick();
                GameStarted();
            }
        }
    }

    public void GameStarted()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);

        MusicManager.instance.PlayGameMusic();
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        StartCoroutine(ScoreManager.instance.UpdateScore());
    }

    public void GameOver()
    {
        gameStarted = false;
        platformSpawner.SetActive(false);

        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel() {
        SceneManager.LoadScene("Game");
    }
}