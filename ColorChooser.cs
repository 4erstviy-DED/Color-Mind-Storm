using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChooser : MonoBehaviour
{
    private Text _colorText;
    private string _randomizedColor;

    private void Start()
    {
        _colorText = GetComponent<Text>();
        RandomizeColor();
    }

    public void RandomizeColor()
    {
        _randomizedColor = ChooseLanguageColor.arrColor[Random.Range(0, ChooseLanguageColor.arrColor.Length)];
        _colorText.text = _randomizedColor;
    }

}
