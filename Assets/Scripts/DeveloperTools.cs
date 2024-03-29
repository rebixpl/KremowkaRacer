using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperTools : MonoBehaviour
{
    public Text DebugKremowkaAmountText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetHighScore()
    {
        ScoreManager.instance.ResetHighScore();
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void InsertKremowka()
    {
        ScoreManager.instance.InsertKremowka(amount: int.Parse(DebugKremowkaAmountText.text));
    }
}
