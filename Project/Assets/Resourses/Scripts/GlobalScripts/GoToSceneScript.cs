using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GoToSceneScript
{
    private static int canvasId;

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
}
