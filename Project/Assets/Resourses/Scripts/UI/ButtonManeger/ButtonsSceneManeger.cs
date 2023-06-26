using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsSceneManeger : MonoBehaviour
{
    public void OnFishtCanvasClick()
    {
        GoToSceneScript.SetCanvasID(0);
        GoToSceneScript.GoToScene("PrimeiroCanvas");
    }

    public void OnSecoundCanvasClick()
    {
        GoToSceneScript.SetCanvasID(1);
        GoToSceneScript.GoToScene("PrimeiroCanvas");
    }

    public void OnStartMenuClick()
    {
        GoToSceneScript.GoToScene("StarterMenuScene");
    }
}
