using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Banking : MonoBehaviour
{
    //Variable for starting balance
    [SerializeField] int m_startingBalance = 150;

    #region This is properties because we're gonna access this variable from another script
    [SerializeField] int m_currentBalance;
    public int _currentBalance { get { return m_currentBalance; } }
    #endregion

    [SerializeField] TextMeshProUGUI _displayBalance;

    // In this start of the game we're gonna set the currentBalance = to starting balance
    private void Awake()
    {
        m_currentBalance = m_startingBalance;
        UpdateDisplay();
    }

    //We are gonna adding the current balance to the parameter amount in this method
    public void Deposit(int amount)
    {
        // Using Mathf.absolute to get absolute value of it
        m_currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    //Reverse method from the deposit
    public void Withdraw(int amount)
    {
        // Using Mathf.absolute to get absolute value of it
        m_currentBalance += Mathf.Abs(amount);
        UpdateDisplay();

        // Logic for loose
        if (m_currentBalance <= 0)
        {
            // Lose logic in here
            ReloadScene();
        }
    }

    public void UpdateDisplay()
    {
        _displayBalance.text = "Gold : " + m_currentBalance;
    }

    // Creating method for ReloadingScene
    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
