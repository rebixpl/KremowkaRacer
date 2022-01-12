using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public Text kremowkaBonusText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI[] kremowkaTotalTexts;
    // public TextMeshProUGUI kremowkaTotalText;

    private int score = 0;
    private int highScore = 0;
    private int kremowkaCollectedTotal = 0;
    private int kremowkaBonus = 0;
    private bool stopScoreCounter = false;

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
        // Load High Score
        highScore = PlayerPrefs.GetInt("HighScore");
        UpdateHighScoreUI();

        // Load Kremowka
        kremowkaCollectedTotal = PlayerPrefs.GetInt("KremowkaAmount");
        UpdateKremowkaUI();

        // Load Kremowka Bonus and display last bonus
        kremowkaBonus = PlayerPrefs.GetInt("KremowkaBonus");
        ShowKremowkaBonusText();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // Kremowka  ------------------------------------------------
    public int GetKremowkaCollectedTotal()
    {
        return kremowkaCollectedTotal;
    }

    public void RemoveKremowka(int amount)
    {
        kremowkaCollectedTotal -= amount;
        UpdateKremowkaUI();
        SaveKremowka();
    }

    public void CalculateKremowkaFromScore()
    {
        kremowkaBonus = (int)(score * GetKremowkaMultiplier());

        // Cache the bonus amount (when game restarts it will show this amount in main menu)
        PlayerPrefs.SetInt("KremowkaBonus", kremowkaBonus);

        KremowkaCollected(kremowkaBonus);
    }

    private void ShowKremowkaBonusText()
    {
        print("kremowka bonus " + kremowkaBonus);
        if (kremowkaBonus == 1)
        {
            kremowkaBonusText.text = "+ 1 BONUS KREMÓWKA ZA WYNIK";
            kremowkaBonusText.gameObject.SetActive(true);
        }
        else if (kremowkaBonus > 1)
        {
            kremowkaBonusText.text = "+ " + kremowkaBonus.ToString() + " BONUS KREMÓWEK ZA WYNIK";
            kremowkaBonusText.gameObject.SetActive(true);
        }

        // Clear the cached bonus value
        PlayerPrefs.SetInt("KremowkaBonus", 0);
        kremowkaBonus = 0;
    }

    private float GetKremowkaMultiplier()
    {
        if (score < 200)
        {
            return 0.1f;
        }
        else if (score >= 200 && score < 1440)
        {
            return 0.05f;
        }
        else
        {
            return 0.035f;
        }
    }

    public void KremowkaCollected(int amount)
    {
        kremowkaCollectedTotal += amount;
        UpdateKremowkaUI();
        SaveKremowka();
    }

    public void UpdateKremowkaUI()
    {
        foreach (var kremowkaText in kremowkaTotalTexts)
        {
            kremowkaText.text = kremowkaCollectedTotal.ToString();
        }
    }

    public void SaveKremowka()
    {

        PlayerPrefs.SetInt("KremowkaAmount", kremowkaCollectedTotal);

    }

    public void InsertKremowka(int amount)
    {
        PlayerPrefs.SetInt("KremowkaAmount", amount);
        kremowkaCollectedTotal = amount;
        UpdateKremowkaUI();
    }

    // High Score ------------------------------------------------
    private void UpdateHighScoreUI()
    {
        highScoreText.text = "NAJWIĘKSZY WYNIK: " + highScore;
    }

    public void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // Player already has a high score
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            // Player don't have a high score, playing for a first time
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void ResetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            highScore = 0;
            UpdateHighScoreUI();
        }
    }

    // Score counter ------------------------------------------------
    public IEnumerator UpdateScore()
    {
        while (true)
        {
            if (!stopScoreCounter)
            {
                // Score Generator
                {
                    if (score < 60)
                    {
                        yield return new WaitForSeconds(1f);
                        score++;
                    }
                    else if (score >= 60 && score < 120)
                    {
                        yield return new WaitForSeconds(0.8f);
                        score++;
                    }
                    else if (score >= 120 && score < 200)
                    {
                        yield return new WaitForSeconds(0.7f);
                        score++;
                    }
                    else if (score >= 200 && score < 360)
                    {
                        yield return new WaitForSeconds(0.6f);
                        score++;
                    }
                    else if (score >= 360 && score < 720)
                    {
                        yield return new WaitForSeconds(0.5f);
                        score++;
                    }
                    else if (score >= 720 && score < 1440)
                    {
                        yield return new WaitForSeconds(0.4f);
                        score++;
                    }
                    else if (score >= 1440 && score < 2137)
                    {
                        yield return new WaitForSeconds(0.3f);
                        score++;
                    }
                    else if (score >= 2137 && score < 3900)
                    {
                        yield return new WaitForSeconds(0.2f);
                        score++;
                    }
                    else if (score >= 3900 && score < 6100)
                    {
                        yield return new WaitForSeconds(0.1f);
                        score++;
                    }
                    else// if (score >= 6100)
                    {
                        yield return new WaitForSeconds(0.05f);
                        score++;
                    }
                }
            }

            scoreText.text = score.ToString();

            //Debug.Log(score);
        }
    }

    public void StopScoreCounter()
    {
        StopCoroutine("UpdateScore");
    }

    public void StartScoreCounter()
    {
        StartCoroutine("UpdateScore");
    }
}