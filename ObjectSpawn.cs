using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] private ColorBlock[] _colorPrefabs;
    [SerializeField] private ColorBlock _firstColorBlock;
    [HideInInspector] public List<ColorBlock> spawnedColors = new List<ColorBlock>();

    private void Start()
    {
        spawnedColors.Add(_firstColorBlock);
    }

    public void SpawnColor()
    {
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
        
    }
}
