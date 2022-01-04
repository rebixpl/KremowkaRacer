using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;

    private int score = 0;
    private int kremowkaCollectedTotal = 0;
    private int kremowkaToAddFromScore = 0;
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
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void CalculateKremowkaFromScore()
    {
        kremowkaToAddFromScore = (int)(score * GetKremowkaMultiplier());
        print(kremowkaToAddFromScore);
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
        stopScoreCounter = true;
    }

    public void StartScoreCounter()
    {
        stopScoreCounter = false;
    }
}