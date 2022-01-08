using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    public List<Color> colors;
    private float timeLeft;
    private Color targetColor;
    private bool fadeColors = false;
    public float bgChangeTime = 10f;

    private void Awake()
    {
        // Generate some random colors
        for (int i = 1; i <= 255; i += 1)
        {
            colors.Add(Random.ColorHSV());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorChanger());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeColors) {
            FadeColors();
        }
    }

    void FadeColors() {
        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            Camera.main.backgroundColor = targetColor;
            timeLeft = 1.0f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }

        if (Camera.main.backgroundColor == targetColor) {
            // fade completed 
            fadeColors = false;
        }
    }

    IEnumerator ColorChanger()
    {
        while (true)
        {
            // start a new transition
            int randColor = Random.Range(0, colors.Count);
            targetColor = colors[randColor];

            // start fading colors
            fadeColors = true;
            
            // wait untill next color change
            yield return new WaitForSeconds(bgChangeTime);
        }
    }
}
