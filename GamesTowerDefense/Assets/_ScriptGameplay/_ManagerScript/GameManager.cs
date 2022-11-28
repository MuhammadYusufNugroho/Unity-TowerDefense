using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Declare Singleton Pattern
    public static GameManager Instance { get; private set; }

    // Variable for Win or Lose
    public GameObject win { get; private set; }
    public GameObject lose { get; private set; }

    // Awake
    private void Awake()
    {
        #region ***Singleton***
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
        #endregion
    }
}