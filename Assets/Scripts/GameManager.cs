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
    public GameObject adsManager;
    public Text gameVersionText;

    private string gameVersion = "0.2.6";

    int adCounter = 0;

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

        CheckAdCount();
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
        // Start spawning platforms
        platformSpawner.SetActive(true);
        PlatformSpawner.instance.StartSpawningPlatforms();

        // Change Camera projection
        CameraFollow.instance.SetOrtographic(true);

        // set rotation towards the first platform
        PopeController.instance.RotateTowardFirstPlatform();

        MusicManager.instance.PlayGameMusic();
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        ScoreManager.instance.StartScoreCounter();
    }

    public void GameOver()
    {
        if (gameStarted)
        {
            ScoreManager.instance.CalculateKremowkaFromScore();
            ScoreManager.instance.SaveHighScore();
            ScoreManager.instance.SaveKremowka();
            gameStarted = false;
            platformSpawner.SetActive(false);
            ScoreManager.instance.StopScoreCounter();

            // Show Ad
            // AdsManager.instance.ShowAd();
            // AdsManager.instance.ShowRewardedAd();

            if (adCounter >= 4)
            {
                // Time to show the ad
                adCounter = 0;
                PlayerPrefs.SetInt("AdCount", adCounter);

                adsManager.GetComponent<InterstitialAds>().ShowAd();
                //AdsManager.instance.ShowAd();
                Invoke("ReloadLevel", 1f);
            }
            else
            {
                // Reload Level, not enough plays to show the ad
                Invoke("ReloadLevel", 1f);
            }

            //Invoke("ReloadLevel", 1f);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    void CheckAdCount()
    {
        if (PlayerPrefs.HasKey("AdCount"))
        {
            adCounter = PlayerPrefs.GetInt("AdCount");
            adCounter++;

            PlayerPrefs.SetInt("AdCount", adCounter);
        }
        else
        {
            // First time player is playing
            adCounter = 0;
            PlayerPrefs.SetInt("AdCount", adCounter);
        }
    }
}