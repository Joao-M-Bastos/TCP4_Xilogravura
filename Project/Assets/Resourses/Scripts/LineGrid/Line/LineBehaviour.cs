using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class LineBehaviour : MonoBehaviour
{

    private LineRenderer lineRenderer;

    private List<Vector3> pointsInGrid;

    private void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    public void UpdateLine(Vector3 position)
    {
        
        if (pointsInGrid == null)
        {
            pointsInGrid = new List<Vector3>();
            SetPoint(position);
            return;
        }
            
        if(Vector3.Distance(pointsInGrid.Last(), position) > 0.1f)
        {
            SetPoint(position);
        }
    }

    void SetPoint(Vector3 point)
    {
        pointsInGrid.Add(point);

        lineRenderer.positionCount = pointsInGrid.Count;

        lineRenderer.SetPosition(pointsInGrid.Count - 1, point);
    }
}
