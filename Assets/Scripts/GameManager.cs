using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;
    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public GameObject menuUI;
    public GameObject settingsUI;
    public Text gameVersionText;

    private string gameVersion = "0.1.6";

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
        // Load Volume Settings at the start
        settingsUI.SetActive(true);
         VolumeSliders.instance.ConfigureMixer();
        settingsUI.SetActive(false);

        gameVersionText.text = "version " + gameVersion;
        MusicManager.instance.PlayMenuMusic();
    }

    // Update is called once per frame
    private void Update()
    {
    }



    public void StartGame()
    {
        // User taps on screen (tap to play area)
        if (!gameStarted)
        {
            SoundsManager.instance.PlayClick();
            GameStarted();
        }
    }

    public void GameStarted()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);

        MusicManager.instance.PlayGameMusic();
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        ScoreManager.instance.StartScoreCounter();
    }

    public void GameOver()
    {
        if (gameStarted) {
            ScoreManager.instance.CalculateKremowkaFromScore();
            ScoreManager.instance.SaveHighScore();
            ScoreManager.instance.SaveKremowka();
            gameStarted = false;
            platformSpawner.SetActive(false);
            ScoreManager.instance.StopScoreCounter();

            Invoke("ReloadLevel", 1f);
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }
}