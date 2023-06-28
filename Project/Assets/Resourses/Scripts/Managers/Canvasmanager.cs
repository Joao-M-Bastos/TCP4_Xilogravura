using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasmanager : MonoBehaviour
{
    public CreateGridScript[] allGrids;

    public GameObject[] preFabs;

    public GameObject pfParent;
    GameObject prefabInScene;

    public GameObject[] preFabsFinais;

    public GameObject pfFinalParent;
    GameObject prefabFinalInScene;

    public int numOfTotalQuads;

    private void Start()
    {
        ReCreateGrids();
    }

    public void PutPreFabsInCanvas()
    {
        if (prefabInScene != null)
            return;

        prefabInScene = Instantiate(preFabs[GoToSceneScript.GetCanvasID()], pfParent.transform);

        prefabFinalInScene = Instantiate(preFabsFinais[GoToSceneScript.GetCanvasID()], pfFinalParent.transform);
        
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

    public void DestroyAssets()
    {
        if (prefabInScene != null)
        {
            Destroy(prefabInScene);
        }
    }

    public bool IsMostCanvasIsClean()
    {
        if (numOfTotalQuads == 0)
        {
            numOfTotalQuads = allGrids[0].IsMostQuadsClean() + allGrids[1].IsMostQuadsClean() + allGrids[2].IsMostQuadsClean() + allGrids[3].IsMostQuadsClean();
        }

        if ( allGrids[0].IsMostQuadsClean() +
            allGrids[1].IsMostQuadsClean() +
            allGrids[2].IsMostQuadsClean() +
            allGrids[3].IsMostQuadsClean() < numOfTotalQuads*0.03f){
            return true;
        }
        return false;
    }

    public bool IsAllCanvasIsClean()
    {
        
        if (allGrids[0].IsAllQuadsClean() &&
            allGrids[1].IsAllQuadsClean() &&
            allGrids[2].IsAllQuadsClean() &&
            allGrids[3].IsAllQuadsClean())
        {
            return true;
        }
        return false;
    }

    public void CleanWhatsLeft()
    {
        allGrids[0].gameObject.SetActive(false);
        allGrids[1].gameObject.SetActive(false);
        allGrids[2].gameObject.SetActive(false);
        allGrids[3].gameObject.SetActive(false);
    }

    public bool IsAllAssetsPainted()
    {
        if(GoToSceneScript.GetCanvasID() == 0)
        {
            if (prefabInScene.GetComponent<AssetPieceBehaviour>().IsPainted)
            {
                return true;
            }
            return false;
        }
        AssetPieceBehaviour[] listOfAssets = prefabInScene.GetComponentsInChildren<AssetPieceBehaviour>();
        Debug.Log(listOfAssets.Length);

        foreach (AssetPieceBehaviour a in listOfAssets)
        {
            if (!a.IsPainted)
                return false;
        }
        return true;
    }
}
