using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Singleton Pattern
    public static GameManager Instance { get; private set; }

    // Logic Win or Lose Variable
    [Header("Logic Winning or Losing")]
    public GameObject win;
    public GameObject lose;

    /*
     * Our To-do
    // Level Manager
     * SetUp Timer 
     * Showing deck 
    // Player Manager Variable
     * Put the tower 
    // Enemy Manager Variable
     * Instantiate Pool Enemy 
*/

    // #Awake
    private void Awake()
    {
        #region Design Patter Singleton Rules
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
        DontDestroyOnLoad(this);
        #endregion

    }

    // #Logic Win or Lose Method
    public void SetOnWin() => win.SetActive(true);
    public void SetOnLose() => lose.SetActive(true);


}

