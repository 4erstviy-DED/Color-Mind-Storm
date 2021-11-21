using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectDestruction : MonoBehaviour
{
    private float _moveDuration;

    private ObjectSpawn _objectSpawn;
    private Transform _destructionPlace;

    public delegate void Send(string ColorName);
    public static event Send SendColor;

    public delegate void SimpleEvent();
    public static event SimpleEvent StopTimer;

    private void Start()
    {
        _objectSpawn = FindObjectOfType<ObjectSpawn>();
        _destructionPlace = GameObject.Find("DestructionPlace").transform;

        _moveDuration = 0.3f;
    }

    private void OnMouseDown()
    {
        DestructionColorBlock();
    }

    private void DestructionColorBlock()
    {
        StopTimer();
        SendColor(gameObject.name);

        var Seq = DOTween.Sequence();

        for (int i = 0; i < _objectSpawn.spawnedColors.Count; i++)
        {
            Seq.Join(_objectSpawn.spawnedColors[i].gameObject.transform.DOMove(_destructionPlace.position, _moveDuration));
        }

        StartCoroutine(DelayBeforeDestruction());
    }

    private IEnumerator DelayBeforeDestruction()
    {
        yield return new WaitForSeconds(_moveDuration);

        for (int i = 0; i < _objectSpawn.spawnedColors.Count; i++)
        {
            Destroy(_objectSpawn.spawnedColors[i].gameObject);
        }

        _objectSpawn.spawnedColors.RemoveRange(0, _objectSpawn.spawnedColors.Count);
    }
}
