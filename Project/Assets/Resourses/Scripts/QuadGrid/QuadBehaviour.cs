using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyParticules;
    [SerializeField] private ParticleSystem sinalyzeParticules;
    

    public void SinalyzeQuad()
    {
        Instantiate(sinalyzeParticules.gameObject, this.transform.position, sinalyzeParticules.gameObject.transform.rotation);
    }

    public void TryDestroyQuad()
    {
        if (Random.Range(0, 4) != 0)
        {
            if (Random.Range(0, 20) == 0)
            {
                GameObject particule = Instantiate(destroyParticules.gameObject, this.transform.position, destroyParticules.gameObject.transform.rotation);
            }

            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AssetPreFab"))
            Destroy(this.gameObject);

        if (other.gameObject.CompareTag("Coifa"))
            TryDestroyQuad();
    }
}
