using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public enum TimeState
    {
        easyLevel,
        mediumLevel,
        hardLevel
    }

    // Level Manager Instance
    public static TimeManager Instance;

    #region Variable for Time Manager
    // Variable for Time Manager
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private float _gameTime;
    public bool _isStopTimer { get; set; }
    #endregion

    EnemyMover enemyMover;

    [SerializeField] GameObject ObjectPools;

    [SerializeField] TimeState timeState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        enemyMover = FindObjectOfType<EnemyMover>();

        // Setup Logic for timer
        _isStopTimer = false;
        _timeSlider.maxValue = _gameTime;
        _timeSlider.value = _gameTime;

        timeState = TimeState.easyLevel;
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

        switch (timeState)
        {
            //Todo Checkout the return value
            case TimeState.easyLevel:
                EasyLevel();
                break;
            case TimeState.mediumLevel:
                EasyLevel();
                break;
            case TimeState.hardLevel:
                EasyLevel();
                break;
            default:
                break;
        }

        if (time <= 0)
        {
            _isStopTimer = true;
            ObjectPools.SetActive(false);
        }
        else if (time <= 120)
        {
            timeState = TimeState.mediumLevel;
        }
        else if (time <= 60)
        {
            timeState = TimeState.hardLevel;
        }
        else if (_isStopTimer == false)
        {
            _timerText.text = textTime;
            _timeSlider.value = time;
        }
    }

    private void EasyLevel()
    {
        enemyMover.Speed = 0.5f;
    }
}
