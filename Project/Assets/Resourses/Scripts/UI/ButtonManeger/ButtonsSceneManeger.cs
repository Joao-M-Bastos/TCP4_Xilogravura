using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsSceneManeger : MonoBehaviour
{
    public GameObject[] canvas;

    private bool cameFromSelecao;

    private void Start()
    {
        if (GoToSceneScript.GetGoToSelecao())
        {
            OnPlayClick();
        }
    }
    public void SetActivation(int i)
    {
        for (int j = 0; j < canvas.Length; j++)
        {
            if (j == i)
                canvas[j].SetActive(true);
            else
                canvas[j].SetActive(false);
        }
    }

    public void OnPlayClick()
    {
        SetActivation(1);
    }

    public void OnOptionsPrincipalClick()
    {
        SetActivation(2);
    }

    public void OnOptionsSelecaoClick()
    {
        cameFromSelecao = true;
        SetActivation(2);
    }

    public void OnCreditosClick()
    {
        SetActivation(3);
    }

    public void OnCloseClick()
    {
        if (cameFromSelecao)
        {
            SetActivation(1);
            cameFromSelecao = false;
            return;
        }

        SetActivation(0);
    }
}
