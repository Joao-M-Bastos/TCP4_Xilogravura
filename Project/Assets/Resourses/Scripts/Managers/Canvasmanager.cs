using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasmanager : MonoBehaviour
{
    public CreateGridNonDestroy backGrid;

    public CreateGridScript[] allGrids;

    public GameObject[] preFabs;

    public GameObject pfParent;
    GameObject prefabInScene;

    public GameObject[] preFabsFinais;

    public GameObject pfFinalParent;
    GameObject prefabFinalInScene;

    private void Start()
    {
        ReCreateGrids();
    }

    public void PutPreFabsInCanvas()
    {
        if (prefabInScene != null)
            return;

        prefabInScene = Instantiate(preFabs[GoToSceneScript.GetCanvasID()], pfParent.transform);

        prefabFinalInScene = Instantiate(preFabsFinais[1], pfFinalParent.transform);

        SetAllCanvasQuadsDestroy(true);
        
    }

    public void Finalizar()
    {
        GoToSceneScript.GoToScene("CompleteScreen");
    }

    public void ReCreateGrids()
    {
        allGrids[0].ReCreateGrid();
        allGrids[1].ReCreateGrid();
        allGrids[2].ReCreateGrid();
        allGrids[3].ReCreateGrid();
    }

    public void SetAllCanvasQuadsDestroy(bool value)
    {
        allGrids[0].SetAllQuadsDestroy(value);
        allGrids[1].SetAllQuadsDestroy(value);
        allGrids[2].SetAllQuadsDestroy(value);
        allGrids[3].SetAllQuadsDestroy(value);
    }

    public void DestroyAssets()
    {
        if (prefabInScene != null)
        {
            Destroy(prefabInScene);
        }
    }

    public bool IsAllCanvasIsClean()
    {
        if( allGrids[0].IsAllQuadsClean() &&
            allGrids[1].IsAllQuadsClean() &&
            allGrids[2].IsAllQuadsClean() &&
            allGrids[3].IsAllQuadsClean()){
            return true;
        }
        return false;
    }
}
