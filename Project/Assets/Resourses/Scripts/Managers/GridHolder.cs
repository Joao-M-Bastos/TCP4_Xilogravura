using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHolder
{

    private static GameObject[] gridObjects;
    
    public static void setGridObjs(GameObject[] grid)
    {
        gridObjects = grid;
    }

    public static GameObject[] getGridObjs()
    {
        return gridObjects;
    }

    public static void resetGridObjs()
    {
        gridObjects = null;
    }

}
