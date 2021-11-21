using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] private ColorBlock[] _colorPrefabs;
    [SerializeField] private ColorBlock _start;

    private Vector3 _startPosition = new Vector3(0, 0, 0);
    private bool _canStartPoint;
    private float _moveDuration;

    public List<ColorBlock> spawnedColors = new List<ColorBlock>();

    public delegate void Requests();
    public static event Requests RequestColor;
    public static event Requests RequestTimer;

    private void Start()
    {
        SwitchRound.NextRound += SpawnColor;
        SpawnColor();

        _moveDuration = 0.5f;
    }

    private void SpawnColor()
    {
        RequestColor?.Invoke();

        if (!_canStartPoint)
        {
            SpawnStartPoint();
        }

        var Seq = DOTween.Sequence();

        for (int i = 0; i < _colorPrefabs.Length; i++)
        {
            ColorBlock tmp = _colorPrefabs[i];
            int j = Random.Range(i, _colorPrefabs.Length);
            _colorPrefabs[i] = _colorPrefabs[j];
            _colorPrefabs[j] = tmp;

            ColorBlock newColorBlock = Instantiate(_colorPrefabs[i]);
            //newColorBlock.transform.position = spawnedColors[spawnedColors.Count - 1].End.position - newColorBlock.Begin.position; //как все должно выглядеть
            spawnedColors.Add(newColorBlock);
        }

        StartCoroutine(DelayBeforeMoving());

        spawnedColors[1].gameObject.transform.position -= new Vector3(0f, 0f, 1);
        RequestTimer();

        _canStartPoint = false;
    }

    private void SpawnStartPoint()
    {
        ColorBlock firstColorBlock = Instantiate(_start);
        firstColorBlock.transform.position = _startPosition;
        spawnedColors.Add(firstColorBlock);
        _canStartPoint = true;
        Debug.Log("SPAWN_START");
    }

    private IEnumerator DelayBeforeMoving()
    {
        yield return new WaitForSeconds(0);

        var Seq = DOTween.Sequence();

        for (int i = 1; i < spawnedColors.Count; i++)
        {
            float positionY = (- i + 0.5f)/2f;

            Seq.Join(spawnedColors[i].gameObject.transform.DOMove(new Vector3(0, positionY, 0), _moveDuration));
        }

    }
}
