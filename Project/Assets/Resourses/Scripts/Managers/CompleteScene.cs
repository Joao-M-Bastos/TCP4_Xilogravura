using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteScene : MonoBehaviour
{
    public GameObject placeToPut;

    private void Awake()
    {
        GameObject[] allGrid = GridHolder.getGridObjs();
        GridHolder.resetGridObjs();

        foreach (GameObject g in allGrid)
        {
            Instantiate(g, placeToPut.transform);
        }
    }
}
