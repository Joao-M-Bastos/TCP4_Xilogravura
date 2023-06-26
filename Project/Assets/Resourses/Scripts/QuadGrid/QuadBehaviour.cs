using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBehaviour : MonoBehaviour
{
    [SerializeField]private bool canBeDestroyed;
    [SerializeField] private ParticleSystem destroyParticules;
    [SerializeField] private ParticleSystem sinalyzeParticules;

    [SerializeField] private bool isColinding;
    
    private void Awake()
    {
        canBeDestroyed = false;
    }

    public void SinalyzeQuad()
    {
        Instantiate(sinalyzeParticules.gameObject, this.transform.position, sinalyzeParticules.gameObject.transform.rotation);
    }

    public void TryDestroyQuad()
    {
        if (canBeDestroyed)
        {
            GameObject particule = Instantiate(destroyParticules.gameObject, this.transform.position, destroyParticules.gameObject.transform.rotation);
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

    public bool GetDestructionType()
    {
        return canBeDestroyed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AssetPreFab"))
            Destroy(this.gameObject);
        if (other.gameObject.CompareTag("Coifa"))
            TryDestroyQuad();
        
        //this.isColinding = true;
        //this.ChangeDestruction(this.canBeDestroyed);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AssetPreFab"))
            this.isColinding = false;
    }
}
