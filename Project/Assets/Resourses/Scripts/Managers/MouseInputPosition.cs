using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputPosition : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Clicked();
        }
    }

    void Clicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent<QuadBehaviour>(out QuadBehaviour quad))
            {
                quad.TryDestroyQuad();
            }
                
        }
    }

}