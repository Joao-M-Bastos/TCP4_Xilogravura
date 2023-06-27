using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGridScript : MonoBehaviour
{
    [SerializeField] private Camera mainOrthograficCamera;

    private float mainCameraSize, quadSize;

    public GameObject quadParent;
    GameObject qpInScene;

    public GameObject quad;

    private MeshRenderer quadMash;

    public int rowNumber, collumNumber;

    private void Awake()
    {
        this.mainOrthograficCamera = Camera.main;

        mainCameraSize = mainOrthograficCamera.orthographicSize;

        quadMash = quad.GetComponent<MeshRenderer>();

        quadSize = quadMash.bounds.size.x;// * transform.localScale.x;
    }

    public void CreateGrid()
    {
        float xStartPoint, yStartPoint;

        xStartPoint = 0;
        yStartPoint = 0;

        for (int j =0; j < rowNumber; j++)
        {
            for (int i = 0; i < collumNumber; i++)
            {
                GameObject a = Instantiate(quad, qpInScene.transform);
                a.transform.SetLocalPositionAndRotation(new Vector3(
                    ((xStartPoint + (quadSize / 2)) + (quadSize * i)),
                    ((yStartPoint - (quadSize / 2)) - (quadSize * j)),
                    0),
                    Quaternion.identity);
                
            }
        }
    }

    public void ReCreateGrid()
    {
            try
            {
                Destroy(qpInScene.gameObject);
            }
            catch
            {

            }
        
        qpInScene = Instantiate(quadParent, this.transform);
        CreateGrid();
    }

    public int IsMostQuadsClean()
    {
        QuadBehaviour[] allQuads;
        allQuads = qpInScene.GetComponentsInChildren<QuadBehaviour>();

        int count = 0;

        foreach (QuadBehaviour q in allQuads)
        {
            count++;
        }
        return count;
    }

    public bool IsAllQuadsClean()
    {
        QuadBehaviour[] allQuads;
        allQuads = qpInScene.GetComponentsInChildren<QuadBehaviour>();

        if (allQuads.Length > 0)
            return false;

        return true;
    }

}
