using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasmanager : MonoBehaviour
{
    public CreateGridNonDestroy backGrid;

    public CreateGridScript[] topGrids;

    public GameObject[] preFabs;

    private void Start()
    {
        backGrid.InstanciateQuads();
        foreach(CreateGridScript c in topGrids)
        {
            c.ReCreateGrid(null);
        }
    }

    public void ReCreateGrids(int i)
    {
        if(i < 0)
        {
            foreach (CreateGridScript c in topGrids)
            {
                c.ReCreateGrid(null);
            }
        }
        else
        {
            topGrids[i].ReCreateGrid(preFabs[i]);
        }
    }
}
