using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int _currentScore = 0;

    public static void AddPoint()
    {
        _currentScore++ ;
    }

    public static int ShowPoint()
    {
        return _currentScore;
    }
}
