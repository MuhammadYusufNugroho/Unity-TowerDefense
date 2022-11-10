using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{


    // Reference
    public Slider timeSlider;
    public TMP_Text timerText;
    public float gameTime;
    public bool stopTimer { get; set; }

    #region *****Singleton*****
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        stopTimer = false;
        timeSlider.maxValue = gameTime;
        timeSlider.value = gameTime;
    }

    private void Update()
    {
        SetupTimer();
    }

    private void SetupTimer()
    {
        float time = gameTime - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)
        {
            stopTimer = true;

        }
        else if (stopTimer == false)
        {
            timerText.text = textTime;
            timeSlider.value = time;
        }
    }
}
