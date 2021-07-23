using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    [SerializeField] private GameObject _colorChooser;
    //private List<ColorBlock> spawnedColors = new List<ColorBlock>();

    private void OnMouseDown()
    {
        //Debug.Log(gameObject.name);
        Destroy(gameObject);
        Score.AddPoint();
    }

    private void OtherColorDestruction()
    {

    }
}
