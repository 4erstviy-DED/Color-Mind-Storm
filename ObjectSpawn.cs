using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] private ColorBlock[] _colorPrefabs;
    [SerializeField] private ColorBlock _start;

    private Vector3 _startPosition = new Vector3(0, 0, 0);
    private bool _hasStartPoint;

    public List<ColorBlock> spawnedColors = new List<ColorBlock>();

    private void Start()
    {
        SpawnStartPoint();
    }

    public void SpawnColor()
    {
        if (!_hasStartPoint)
        {
            SpawnStartPoint();
        }

        for (int i = 0; i < _colorPrefabs.Length; i++)
        {
            ColorBlock tmp = _colorPrefabs[i];
            int j = Random.Range(i, _colorPrefabs.Length);
            _colorPrefabs[i] = _colorPrefabs[j];
            _colorPrefabs[j] = tmp;

            ColorBlock newColorBlock = Instantiate(_colorPrefabs[i]);
            newColorBlock.transform.position = spawnedColors[spawnedColors.Count - 1].End.position - newColorBlock.Begin.position;
            spawnedColors.Add(newColorBlock);
        }

        _hasStartPoint = false;
    }

    private void SpawnStartPoint()
    {
        ColorBlock firstColorBlock = Instantiate(_start);
        firstColorBlock.transform.position = _startPosition;
        spawnedColors.Add(firstColorBlock);
        _hasStartPoint = true;
        Debug.Log("SPAWN_START");
    }
}
