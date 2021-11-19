using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRound : MonoBehaviour
{
    public delegate void Switch();
    public static event Switch NextRound;

    private bool _nextRound = false;

    private ObjectSpawn _objectSpawn;

    private void Start()
    {
        _objectSpawn = FindObjectOfType<ObjectSpawn>();

        AdditionScore.NextRound += TruthNextRound;
    }

    private void Update()
    {
        if ((_nextRound) && _objectSpawn.spawnedColors.Count == 0)
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
