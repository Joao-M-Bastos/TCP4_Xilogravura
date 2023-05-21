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

    private void Awake()
    {
        //cooldown = 1;


        quadSize = (quad.GetComponent<MeshRenderer>().bounds.size.x / 1.4f) * ((float)Screen.width / 680);
    }
    private void Update()
    {
        //if(cooldown <= 0)
        //{
        //    cooldown = 0.1f;
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Clicked();
            lastMousePos = Input.mousePosition;
        }

        //}
        //else
        //{
        //    cooldown -= Time.deltaTime;
        //}
    }

    void Clicked()
    {
        newMousePos = Input.mousePosition;
        if (newMousePos != lastMousePos)
        {
            if(CheckDisctances(newMousePos, lastMousePos, 1.85f))
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

        for (int i = 0; i < 13; i++)
        {
            RaycastHit hit = new RaycastHit();

            //lastMousePos agora é a posição atual
            mousePos = Input.mousePosition;

            switch (i)
            {
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
                    mousePos.x -= quadSize * 2;
                    break;
                case 6:
                    mousePos.x -= quadSize;
                    break;
                case 7:
                    mousePos.x += quadSize;
                    break;
                case 8:
                    mousePos.x += quadSize * 2;
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
            }

            ray = Camera.main.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent<QuadBehaviour>(out QuadBehaviour quad))
                {
                    quad.TryDestroyQuad();
                }
            }
        }
    }
}