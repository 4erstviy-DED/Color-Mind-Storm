using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void EndTime();
    public static event EndTime TimeOver;

    private void MovingLine()
    {
        transform.position -= new Vector3(0.01f, 0, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Lose");
        Destroy(gameObject);
        TimeOver();
    }

    private void FixedUpdate()
    {
        MovingLine();
    }
}
