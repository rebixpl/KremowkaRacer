using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class VolumeSliders : MonoBehaviour
{
    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }

    public static VolumeSliders instance;

    public AudioMixer mixer;

    [SerializeField]
    private string volmeName;

    [SerializeField]
    private Text volumeLabel;

    private float volumeValue;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        ConfigureMixer();
    }

    public void ConfigureMixer()
    {
        // Only for debug, clears data stored on the device (also saved volume levels)
        // PlayerPrefs.DeleteAll();

        // Load saved volume settings
        if (PlayerPrefs.HasKey(volmeName + "Slider"))
        {
            volumeValue = PlayerPrefs.GetFloat(volmeName + "Slider");
        }
        else
        {
            // Player has not set slider value, set default 1.0
            volumeValue = 1.0f;
            PlayerPrefs.SetFloat(volmeName + "Slider", volumeValue);
        }

        UpdateValueOnChange(volumeValue);

        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }

    public void UpdateValueOnChange(float value)
    {
        if (mixer != null)
        {
            volumeValue = Mathf.Log(value) * 20f;

            mixer.SetFloat(volmeName, volumeValue);
            slider.value = value;

            PlayerPrefs.SetFloat(volmeName + "Slider", value);
        }

        if (volumeLabel != null)
        {
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
        }
    }
}
