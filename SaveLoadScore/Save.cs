using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static void SaveScore(string key, int score)
    {
        PlayerPrefs.SetInt(key, score);
    }

    public static void SaveLanguage(string key, string language)
    {
        PlayerPrefs.SetString(key, language);
    }
}
