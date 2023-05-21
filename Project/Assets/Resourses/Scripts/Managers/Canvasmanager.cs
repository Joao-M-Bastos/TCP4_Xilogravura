using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasmanager : MonoBehaviour
{
    public CreateGridNonDestroy backGrid;

    public CreateGridScript[] allGrids;

    public GameObject[] preFabs;

    private void Start()
    {
        backGrid.InstanciateQuads();
        foreach(CreateGridScript c in allGrids)
        {
            c.ReCreateGrid(null);
        }
    }

    public void ReCreateGrids(int i)
    {
        if(i < 0)
        {
            foreach (CreateGridScript c in allGrids)
            {
                c.ReCreateGrid(null);
            }
        }
        else
        {
            for(int j = 0; j < 3; j++)
            {
                allGrids[(j * 4) + i].ReCreateGrid(preFabs[i]);
            }
        }
    }

    public void Finalizar()
    {
        GameObject[] allGridsObjs = new GameObject[12];

        for(int i = 0; i < allGridsObjs.Length; i ++) {
            allGrids[i].DestroyAssets();
            allGridsObjs[i] = allGrids[i].gameObject;
        }

        GridHolder.setGridObjs(allGridsObjs);

        GoToSceneScript.GoToScene("CompleteScreen");
    }
}
