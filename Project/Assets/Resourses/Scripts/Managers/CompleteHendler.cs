using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteHendler : MonoBehaviour
{
    public GameObject[] completePreFabs;

    [SerializeField] bool doActivation;
    // Start is called before the first frame update
    private void Update()
    {
        if(doActivation)
        {
            SetActiveCanvas();
            doActivation = false;
        }
    }

    public void SetActiveCanvas()
    {
        Instantiate(completePreFabs[GoToSceneScript.GetCanvasID()], this.transform);
    }
}
