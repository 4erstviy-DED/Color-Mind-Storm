using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    private ObjectSpawn _objectSpawn;

    private void Start()
    {
        _objectSpawn = FindObjectOfType<ObjectSpawn>();
    }

    private void OnMouseDown()
    {
        DestructionColorBlock();
    }

    private void DestructionColorBlock()
    {
        //Destroy(gameObject);
        Score.AddPoint();

        for (int i = 0; i < _objectSpawn.spawnedColors.Count; i++)
        {
            Destroy(_objectSpawn.spawnedColors[i].gameObject);
            Debug.Log(_objectSpawn.spawnedColors[i].name);
        }

        _objectSpawn.spawnedColors.RemoveRange(0, _objectSpawn.spawnedColors.Count);
    }
}
