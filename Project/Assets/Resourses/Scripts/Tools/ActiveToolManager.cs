using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveToolManager : MonoBehaviour
{
    [SerializeField] GameObject[] tools;


    public void SelectCoifa()
    {
        tools[0].SetActive(true);
        tools[1].SetActive(false);
    }

    public void SelectRoloTinta()
    {
        tools[0].SetActive(false);
        tools[1].SetActive(true);
    }

    public void NoToolSelected()
    {
        tools[0].SetActive(false);
        tools[1].SetActive(false);
    }

    public void GoToPosition(Vector3 newPosition)
    {
        newPosition.y = 0.8f;
        this.gameObject.transform.position = newPosition;
    }
}
