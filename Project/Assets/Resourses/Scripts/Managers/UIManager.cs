using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvasmanager canvasmanager;
    [SerializeField] ActiveToolManager toolmanager;

    [SerializeField] GameObject[] buttons;

    [SerializeField]  Animator cameraAnimator;

    private void Awake()
    {
        Talhando();
    }

    public void SetActivation(int i)
    {
        for(int j = 0; j < buttons.Length; j++)
        {
            if(j == i)                         
                buttons[j].SetActive(true);
            else
                buttons[j].SetActive(false);
        }
    }

    public void Talhando()
    {
        SetActivation(0);

        toolmanager.SelectCoifa();
        canvasmanager.PutPreFabsInCanvas();

        StartCoroutine(CanGoToPintar());
    }

    private IEnumerator CanGoToPintar()
    {
        yield return new WaitForSeconds(2);
        if (!canvasmanager.IsAllCanvasIsClean())
        {
            StartCoroutine(CanGoToPintar());
        }
        else
        {
            Pintar();
        }
    }

    public void Pintar()
    {
        toolmanager.SelectRoloTinta();
        canvasmanager.CleanWhatsLeft();
        SetActivation(1);

        Finalizar();
    }

    public void Finalizar()
    {
        SetActivation(3);

        cameraAnimator.SetTrigger("Final");
    }

}
