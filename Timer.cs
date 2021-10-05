using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void Time();
    public static event Time TimeOver;

    private void Awake()
    {
        EndGame.TimeOver += CleanObject;
        ObjectSpawn.RequestTimer += RespawnTimer;

        RespawnTimer();
    }

    private void MovingLine()
    {
        transform.position -= new Vector3(0.01f, 0, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Lose");
        TimeOver();
    }

    private void FixedUpdate()
    {
        MovingLine();
    }

    private void CleanObject()
    {
        gameObject.SetActive(false);
    }

    private void RespawnTimer()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
