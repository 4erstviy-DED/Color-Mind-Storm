using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    private ObjectSpawn _objectSpawn;

    public delegate void Send(string ColorName);
    public static event Send SendColor;

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
        Destroy(gameObject);
        SendColor(gameObject.name);

        for (int i = 0; i < _objectSpawn.spawnedColors.Count; i++)
        {
            Destroy(_objectSpawn.spawnedColors[i].gameObject);
        }

        _objectSpawn.spawnedColors.RemoveRange(0, _objectSpawn.spawnedColors.Count);
    }
}
