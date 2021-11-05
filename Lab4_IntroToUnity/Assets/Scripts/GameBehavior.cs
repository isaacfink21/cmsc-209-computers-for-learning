using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
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
                    showWinScreen = true;
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
        set {
        _playerHP = value;
        Debug.LogFormat("Health: {0}", _playerHP);
        }
    }
    void OnGUI()
    {
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "YOU WON!")){}
        }

        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" +
            _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Goals Collected: " +
            _goalsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height -
            0, 500, 100), labelText);}
}
