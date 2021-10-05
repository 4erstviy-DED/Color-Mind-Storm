using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRound : MonoBehaviour
{
    public delegate void Switch();
    public static event Switch NextRound;

    private bool _nextRound = false;

    private void Start()
    {
        AdditionScore.NextRound += TruthNextRound;
    }

    private void FixedUpdate()
    {
        if (_nextRound)
        {
            NextRound();
            _nextRound = false;
        }
    }

    private void TruthNextRound()
    {
        _nextRound = true;
    }

}
