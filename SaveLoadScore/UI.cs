using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Text _maxScore;

    private void Start()
    {
        _maxScore = GetComponent<Text>();
        AdditionScore.LoseGame += OutputHighScoreAtUI;
    }

    private void OutputHighScoreAtUI(int score)
    {
        _maxScore.text = "Max " + Load.LoadScore("MaxScore");
    }
}
