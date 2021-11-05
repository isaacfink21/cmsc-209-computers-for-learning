using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public int showWinScreen = 0;
    public string labelText = "Don't die lol";
    private int _goalsCollected = 0;
    public int Goals
    {
        get { return _goalsCollected; }
        set {
            _goalsCollected = value;
            if (_goalsCollected  >= 1)
                {
                    labelText = "You've found all the items!";
                    showWinScreen += 100;
                }
                else
                {
                    labelText = "Item found, only " + (1 - 
                        _goalsCollected) + " more to go!";
                }
        }
    }

    public int _playerHP = 100;
    public int HP
    {
        get { return _playerHP; }
        set 
        {
                _playerHP = value;
                Debug.LogFormat("Health: {0}", _playerHP);
        }
    }


    public int _obstaceleHealth = 100;
    public int ObstacleHealth
    {
        get {return _obstaceleHealth;}
        set {
            _obstaceleHealth = value;
            Debug.LogFormat("Obstacle Health: {0}", _obstaceleHealth);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        if (showWinScreen > 0)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "YOU WON!")){}
            if (Input.GetMouseButtonDown(0))
            {
                RestartLevel();
            }

        }
        if (showWinScreen < 0)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "YOU LOST!")){}
            if (Input.GetMouseButtonDown(0))
            {
                RestartLevel();
            }
        }

        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" +
            _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Goals Collected: " +
            _goalsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height -
            0, 500, 100), labelText);}
}
