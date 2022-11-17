using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class LevelManager : MonoBehaviour
{
    #region Variable for Time Manager
    // Variable for Time Manager
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private float _gameTime;
    [SerializeField] private bool _isStopTimer { get; set; }
    #endregion

    private void Start()
    {
        _isStopTimer = false;
        _timeSlider.maxValue = _gameTime;
        _timeSlider.value = _gameTime;
    }

    private void Update()
    {
        SetupTimer();
    }

    private void SetupTimer()
    {
        // Logic for Timer
        float time = _gameTime - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);
        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)
            _isStopTimer = true;
        else if (_isStopTimer == false)
            _timerText.text = textTime; _timeSlider.value = time;

    }
}
