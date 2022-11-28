using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Level Manager Instance
    public static TimeManager Instance;

    #region Variable for Time Manager
    // Variable for Time Manager
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private float _gameTime;
    public bool _isStopTimer { get; set; }
    #endregion

    [SerializeField] GameObject ObjectPools;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Setup Logic for timer
        _isStopTimer = false;
        _timeSlider.maxValue = _gameTime;
        _timeSlider.value = _gameTime;
    }

    private void Update()
    {
        // Call method
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
        {
            _isStopTimer = true;
            ObjectPools.SetActive(false);
        }
        else if (_isStopTimer == false)
        {
            _timerText.text = textTime;
            _timeSlider.value = time;
        }

    }
}
