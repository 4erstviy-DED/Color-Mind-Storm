using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionScore : MonoBehaviour
{
    private int _currentScore = 0;
    private Text _score;

    private void Start()
    {
        ObjectDestruction.SendColor += GetColor;
        ColorChooser.SendColorName += GetColorName;
        _score = GetComponent<Text>();
    }

    private void GetColor(string name)
    {
        Debug.Log(name.Remove(name.Length -7)); //обрезание приставки (Clone)
        AddPointToScore();
    }

    private void GetColorName(string name)
    {
        Debug.Log(name);
    }

    private void AddPointToScore()
    {
        _currentScore++ ;
        _score.text = $"SCORE: {_currentScore}";
    }
}
