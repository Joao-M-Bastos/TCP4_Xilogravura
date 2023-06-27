using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveToolManager : MonoBehaviour
{
    [SerializeField] GameObject[] tools;

    [SerializeField] GameObject[] coifaColliders;
    public void SelectCoifa()
    {
        tools[0].SetActive(true);
        tools[1].SetActive(false);
        tools[2].SetActive(false);
    }

    public void SelectLixa()
    {
        tools[0].SetActive(false);
        tools[1].SetActive(true);
        tools[2].SetActive(false);
    }

    public void SelectRoloTinta()
    {
        tools[0].SetActive(false);
        tools[1].SetActive(false);
        tools[2].SetActive(true);
    }

    public void NoToolSelected()
    {
        tools[0].SetActive(false);
        tools[1].SetActive(false);
    }

    public void SetCollidersOff()
    {
        foreach(GameObject go in coifaColliders)
        {
            go.SetActive(false);
        }
    }
    public void SetCollidersOn()
    {
        foreach (GameObject go in coifaColliders)
        {
            go.SetActive(true);
        }
    }

    public void GoToPosition(Vector3 newPosition)
    {
        newPosition.y = 0.8f;
        this.gameObject.transform.position = newPosition;
    }
}
