using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLanguageColor : MonoBehaviour
{
    public static string[] arrColor = new string[] {"RED", "GREEN","BLUE", "PINC", "YELLOW", "PURPLE" };

	public void ChooseLanguage()
    {
        switch (gameObject.name)
        {
            case "eng":
                arrColor[0] = "RED";
                arrColor[1] = "GREEN";
                arrColor[2] = "BLUE";
                arrColor[3] = "PINC";
                arrColor[4] = "YELLOW";
                arrColor[5] = "PURPLE";
                break;
            case "rus":
                arrColor[0] = "КРАСНЫЙ";
                arrColor[1] = "ЗЕЛЕНЫЙ";
                arrColor[2] = "СИНИЙ";
                arrColor[3] = "РОЗОВЫЙ";
                arrColor[4] = "ЖЕЛТЫЙ";
                arrColor[5] = "ФИОЛЕТОВЫЙ";
                break;
        }
    }

}
