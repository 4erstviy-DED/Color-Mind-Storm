using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void Time();
    public static event Time TimeOver;

    private bool _canMoving;

    private void Awake()
    {
        EndGame.TimeOver += CleanObject;
        ObjectSpawn.RequestTimer += RespawnTimer;
        ObjectDestruction.StopTimer += StopTimer;

        RespawnTimer();
    }

    private void MovingLine()
    {
        transform.position -= new Vector3(0.015f, 0, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Lose");
        TimeOver();
    }

    private void FixedUpdate()
    {
        if (_canMoving)
        {
            MovingLine();
        }
    }

    private void CleanObject()
    {
        gameObject.SetActive(false);
    }

    private void StopTimer()
    {
        _canMoving = false;
    }

    private void RespawnTimer()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        _canMoving = true;
    }
}
