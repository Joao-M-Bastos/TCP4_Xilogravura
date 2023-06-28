using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GoToSceneScript
{
    private static int canvasId;

    private static bool haveSound = true;

    private static bool goToSelecao;

    public static void GoToScene(string sceneName = "")
    {
        if(sceneName != "")
            SceneManager.LoadScene(sceneName);
    }

    public static int GetCanvasID()
    {
        return canvasId;
    }

    public static void SetCanvasID(int value)
    {
        canvasId = value;
    }

    public static void SetGoToSelecao()
    {
        goToSelecao = true;
    }

    public static bool GetGoToSelecao()
    {
        bool value = goToSelecao;
        goToSelecao = false;
        return value;
    }

    public static bool GetSound()
    {
        return haveSound;
    }

    public static void ChangeSound()
    {
        haveSound = !haveSound;
    }
}
