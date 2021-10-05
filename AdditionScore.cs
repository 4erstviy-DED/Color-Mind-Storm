using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionScore : MonoBehaviour
{
    private int _currentScore = 0;
    private Text _score;
    private string _chosenColor;
    private string _chosenNameColor;

    public delegate void SimpleEvent();
    public delegate void EndGame(int currentScore);
    
    public static event SimpleEvent LoseGame;
    public static event SimpleEvent NextRound;

    public static event EndGame SendScore;

    private void Start()
    {
        ObjectDestruction.SendColor += GetColor;
        ColorChooser.SendColorName += GetColorName;
        _score = GetComponent<Text>();
    }
    
    private void GetColorName(string name)
    {
        _chosenNameColor = name;
    }

    private void GetColor(string name)
    {
        _chosenColor = name.Remove(name.Length - 7); //обрезание приставки (Clone)
        AddPointToScoreOrLose();
    }

    private void AddPointToScoreOrLose()
    {
        if (_chosenColor == _chosenNameColor)
        {
            _currentScore++;
            _score.text = $"SCORE: {_currentScore}";
            SendScore(_currentScore);
            NextRound();
        }
        else
        {
            LoseGame();
        }
    }

}
