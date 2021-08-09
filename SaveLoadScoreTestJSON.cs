using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadScoreTestJSON : MonoBehaviour
{
    private static string _path;
    private Data _data;

    private void Start()
    {
        _path = Path.Combine(Application.streamingAssetsPath + "/saves.json");
        _data = LoadData<Data>();
    }

    public static T LoadData<T>()
    {
        if (File.Exists(_path))
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(_path));
        }
        else
        {
            return default(T);
        }
    }

    public static void SaveData(object obj)
    {
        File.WriteAllText(_path, JsonUtility.ToJson(obj));
    }

    private class Data
    {
        public string Language;
        public int MaxScore;
    }
}
