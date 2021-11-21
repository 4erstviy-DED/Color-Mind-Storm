using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Text _maxScore;

    private void Awake()
    {
        _maxScore = GetComponent<Text>();
        //AdditionScore.LoseGame += OutputHighScoreAtUI;
    }

    private void Start()
    {
        OutputHighScoreAtUI();
    }

    private void OutputHighScoreAtUI()
    {
        _maxScore.text = "Max " + Load.LoadScore("MaxScore");
        Debug.Log("OutputHighScore");
    }
}
