using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSceneManeger : MonoBehaviour
{
    public static void OnFishtCanvasClick()
    {
        GoToSceneScript.GoToScene("PrimeiroCanvas");
    }

    public static void OnSecoundCanvasClick()
    {
        GoToSceneScript.GoToScene("SegundoCanvas");
    }

    public static void OnStartMenuClick()
    {
        GoToSceneScript.GoToScene("StarterMenuScene");

    }
}
