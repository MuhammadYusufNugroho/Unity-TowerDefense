using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class LevelManager : MonoBehaviour
{
    private enum StateLevel
    {
        easy,
        moderate,
        hard
    }

    [SerializeField] private StateLevel stateLevel;

    #region Variable for Time Manager
    // Reference
    public Slider timeSlider;
    public TMP_Text timerText;
    public float gameTime;
    public bool stopTimer { get; set; }
    private StateLevel StateLevel1 { get => stateLevel; set => stateLevel = value; }
    #endregion

    [SerializeField] GameObject[] stateimages = new GameObject[3];

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

        //todo Tweak this one out
        /*
        if (time <= 180)
            StartCoroutine(WaitStateLevel());
        else if (time <= 120)
            stateimages[1].gameObject.SetActive(true);
        else if (time <= 60)
            stateimages[2].gameObject.SetActive(true);
        */


    }


    public IEnumerator WaitStateLevel()
    {
        stateimages[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        stateimages[0].gameObject.SetActive(false);
        yield return null;
    }

}
