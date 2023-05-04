using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBehaviour : MonoBehaviour
{
    [SerializeField]private bool canBeDestroyed;

    [SerializeField] private bool isColinding;
    
    private void Awake()
    {
        canBeDestroyed = false;
    }

    public void TryDestroyQuad()
    {
        if (canBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeDestruction(bool value)
    {
        if (isColinding) {
            this.canBeDestroyed = false;
            return;
        }

        this.canBeDestroyed = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if (other.gameObject.CompareTag("AssetPreFab"))
            this.isColinding = true;
        this.ChangeDestruction(this.canBeDestroyed);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AssetPreFab"))
            this.isColinding = false;
    }
}
