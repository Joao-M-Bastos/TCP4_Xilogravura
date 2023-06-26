using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputPosition : MonoBehaviour
{
    [SerializeField] GameObject quad;
    private float quadSize;
    Vector3 newMousePos, lastMousePos;
    //float cooldown;

    [SerializeField]ActiveToolManager toolManager;

    private void Awake()
    {
        //cooldown = 1;

        quadSize = (quad.GetComponent<MeshRenderer>().bounds.size.x / 1.4f) * ((((float)Screen.width / 750)+((float)Screen.height / 469))/2);

    }
    private void Update()
    {
        //if(cooldown <= 0)
        //{
        //    cooldown = 0.1f;
        if (Input.touchCount > 0)
        {
            //lastMousePos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0)
        {
            Clicked();
            lastMousePos = Input.GetTouch(0).position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked();
            lastMousePos = Input.mousePosition;
        }
         
        //}
        //else
        //{
        //    cooldown -= Time.deltaTime;
        //}
    }

    private void MouseClicked()
    {
        newMousePos = Input.mousePosition;
        if (newMousePos != lastMousePos)
        {
            //if(CheckDisctances(newMousePos, lastMousePos, 3f))
            GenerateRays();
        }
    }

    void Clicked()
    {
        newMousePos = Input.GetTouch(0).position;
        if (newMousePos != lastMousePos)
        {
            //if(CheckDisctances(newMousePos, lastMousePos, 3f))
                GenerateRays();
        }
    }

    private bool CheckDisctances(Vector3 pos1, Vector3 pos2, float maxDistance)
    {
        if (Vector3.Distance(pos1, pos2) < maxDistance)
            return true;
        return false;
    }

    private void GenerateRays()
    {
        Ray ray;
        Vector3 mousePos;

        for (int i = 0; i < 19; i++)
        {
            RaycastHit hit = new RaycastHit();

            //lastMousePos agora é a posição atual
            mousePos = newMousePos;

            switch (i)
            {
                case 0:
                    PlaceToolInCanvas(mousePos);
                    break;
                case 1:
                    mousePos.y += quadSize *2; 
                    break;
                case 2:
                    mousePos.y += quadSize;
                    mousePos.x -= quadSize;
                    break;
                case 3:
                    mousePos.y += quadSize;
                    break;
                case 4:
                    mousePos.y += quadSize;
                    mousePos.x += quadSize;
                    break;
                case 5:
                    mousePos.y -= quadSize * 3;
                    break;
                case 6:
                    mousePos.x -= quadSize;
                    break;
                case 7:
                    mousePos.x += quadSize;
                    break;
                case 8:
                    mousePos.y += quadSize * 3;
                    break;
                case 9:
                    mousePos.y -= quadSize;
                    mousePos.x -= quadSize;
                    break;
                case 10:
                    mousePos.y -= quadSize;
                    break;
                case 11:
                    mousePos.y -= quadSize;
                    mousePos.x += quadSize;
                    break;
                case 12:
                    mousePos.y -= quadSize * 2;
                    break;
                case 13:
                    mousePos.y -= quadSize * 2;
                    mousePos.x += quadSize;
                    break;
                case 14:
                    mousePos.y += quadSize * 2;
                    mousePos.x += quadSize;
                    break;
                case 15:
                    mousePos.y -= quadSize * 2;
                    mousePos.x -= quadSize;
                    break;
                case 16:
                    mousePos.y += quadSize * 2;
                    mousePos.x -= quadSize;
                    break;
                case 17:
                    mousePos.y -= quadSize * 4;
                    break;
                case 18:
                    mousePos.y += quadSize * 4;
                    break;
            }

            ray = Camera.main.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out QuadBehaviour quad))
                {
                    quad.TryDestroyQuad();
                }
            }
        }
    }

    private void PlaceToolInCanvas(Vector3 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out QuadBehaviour quad)||
                hit.collider.gameObject.CompareTag("AssetPreFab"))
            {
                toolManager.GoToPosition(hit.point);
            }
        }
    }
}