using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGeneratorScpt : MonoBehaviour
{
    public GameObject linePrefab;
    private LineBehaviour activeLine;

    public Transform endPointTrans;
    private Vector3 endPointPos;

    private bool hasMoved;

    private void Awake()
    {
        // endPointTrans = this.GetComponent<MeshRenderer>();
        endPointPos = endPointTrans.position;

    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<LineBehaviour>();
            hasMoved = false;
        }



        if (Input.GetMouseButtonUp(0) || IsOutOfBorder(mousePos))
        {
            if (!hasMoved && activeLine!= null)
                Destroy(activeLine.gameObject);
            else
                activeLine = null;
        }

        if (activeLine != null)
        {
            hasMoved = true;
            mousePos.y = 0;

            activeLine.UpdateLine(mousePos);
        }

    }

    private bool IsOutOfBorder(Vector3 position)
    {
        if (position.x < this.transform.position.x || position.x > endPointPos.x)
            return true;


        if (position.z > this.transform.position.z || position.z < endPointPos.z)
            return true;

        return false;
    }
}
