using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] private ColorBlock[] _colorPrefabs;
    [SerializeField] private ColorBlock _firstColorBlock;
    private List<ColorBlock> spawnedColors = new List<ColorBlock>();

    private ColorChooser _colorRandomizer;

    private void Start()
    {
        _colorRandomizer = gameObject.GetComponent<ColorChooser>();
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
            Debug.Log(i);

            ColorBlock newColorBlock = Instantiate(_colorPrefabs[i]);
            newColorBlock.transform.position = spawnedColors[spawnedColors.Count - 1].End.position - newColorBlock.Begin.localPosition;
            spawnedColors.Add(newColorBlock);
        }
        
    }
}
