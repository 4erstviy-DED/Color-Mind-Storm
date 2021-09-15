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

    private void Awake()
    {
        AdditionScore.LoseGame += GetScorePoint;
        Timer.TimeOver += SpawnEndPanel;
        _endPanelScoreText = _endPanelScore.GetComponent<Text>();
    }

    private void GetScorePoint(int currentScore)
    {
        _endPanelScoreText.text = $"SCORE: {currentScore}";
        SpawnEndPanel();
    }

    private void SpawnEndPanel()
    {
        _endPanel.SetActive(true);
        _scoreGame.SetActive(false);
        _colorGame.SetActive(false);
    }
}
