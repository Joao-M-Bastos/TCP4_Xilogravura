using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGridScript : MonoBehaviour
{
    [SerializeField] private Camera mainOrthograficCamera;

    private float mainCameraSize, quadSize;

    public GameObject quadParent;
    GameObject qpInScene, prefabInScene;

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
                    a.transform.position.z),
                    Quaternion.identity);
                
            }
        }
    }

    public void ReCreateGrid(GameObject prefab)
    {
        if (prefab == null)
        {
            Destroy(prefabInScene);
            qpInScene = Instantiate(quadParent, this.transform);
            CreateGrid();
            return;
        }

        if (prefabInScene != null)
        {
            Destroy(prefabInScene);
            SetAllQuadsDestroy(false);
        }
        else
        {
            Destroy(qpInScene.gameObject);
            qpInScene = Instantiate(quadParent, this.transform);
            CreateGrid();
            prefabInScene = Instantiate(prefab, qpInScene.transform);
            SetAllQuadsDestroy(true);
        }
    }

    private void SetAllQuadsDestroy(bool b)
    {
        QuadBehaviour[] allQuads;
        allQuads = qpInScene.GetComponentsInChildren<QuadBehaviour>();

        foreach(QuadBehaviour q in allQuads)
        {
            q.ChangeDestruction(b);
        }
    }
}
