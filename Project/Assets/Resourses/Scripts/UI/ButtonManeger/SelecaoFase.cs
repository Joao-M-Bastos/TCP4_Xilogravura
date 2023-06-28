using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecaoFase : MonoBehaviour
{
    public void OnFirstCanvasClick()
    {
        GoToScene(0);
    }

    public void OnSecondCanvasClick()
    {
        GoToScene(1);
    }

    private void GoToScene(int canvasId)
    {
        GoToSceneScript.SetCanvasID(canvasId);
        GoToSceneScript.GoToScene("PrimeiroCanvas");
    }
}
