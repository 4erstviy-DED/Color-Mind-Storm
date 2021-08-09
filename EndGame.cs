using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;

    private void Awake()
    {
        AdditionScore.LoseGame += SpawnEndPanel;
    }

    private void SpawnEndPanel()
    {
        gameObject.SetActive(true);
    }
}
