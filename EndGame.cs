using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _endPanelScore;
    [SerializeField] private GameObject _scoreGame;
    [SerializeField] private GameObject _colorGame;

    private Text _endPanelScoreText;
    private int _finalScore = 0;

    public delegate void EndTime();
    public static event EndTime TimeOver;

    private void Awake()
    {
        AdditionScore.LoseGame += Lose;
        AdditionScore.SendScore += GetScorePoint;
        Timer.TimeOver += SpawnEndPanel;

        _endPanelScoreText = _endPanelScore.GetComponent<Text>();
    }

    private void GetScorePoint(int currentScore)
    {
        _finalScore = currentScore;
    }

    private void Lose()
    {
        SpawnEndPanel();
    }

    private void SpawnEndPanel()
    {
        _endPanelScoreText.text = $"SCORE: {_finalScore}";
        _endPanel.SetActive(true);
        _scoreGame.SetActive(false);
        _colorGame.SetActive(false);
        TimeOver();
    }
}
