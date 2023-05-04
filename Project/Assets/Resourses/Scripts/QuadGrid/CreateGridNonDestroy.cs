using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGridNonDestroy : MonoBehaviour
{
    [SerializeField] private Camera mainOrthograficCamera;

    private float mainCameraSize, quadSize;

    public GameObject quadParent;
    GameObject qpInScene;

    public GameObject quad;

    private MeshRenderer quadMash;

    public int rowNumber, collumNumber;

    private bool canBeDestroyed;

    private void Awake()
    {
        this.mainOrthograficCamera = Camera.main;

        mainCameraSize = mainOrthograficCamera.orthographicSize;

        quadMash = quad.GetComponent<MeshRenderer>();

        quadSize = quadMash.bounds.size.x;// * transform.localScale.x;
    }

    public void InstanciateQuads()
    {
        qpInScene = Instantiate(quadParent, this.transform);

        float xStartPoint, yStartPoint;

        xStartPoint = 0;
        yStartPoint = 0;

        this.canBeDestroyed = !this.canBeDestroyed;

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


                a.GetComponent<QuadBehaviour>().ChangeDestruction(false);
            }
        }
    }

    public void DestroyGrid()
    {
        Destroy(qpInScene.gameObject);
    }
}
