using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPieceBehaviour : MonoBehaviour
{
    [SerializeField] Material inkMaterial, woodMaterial;

    private bool isPainted, isLixado;

    public bool IsPainted => isPainted;
    public bool IsLixado => isLixado;

    public void SetMaterialToInk()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = inkMaterial;
        isPainted = true;
    }

    public void SetMaterialToWood()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = woodMaterial;
        isLixado = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pincel"))
        {
            SetMaterialToInk();
        }

        if (other.gameObject.CompareTag("Lixa"))
        {
            SetMaterialToWood();
        }
    }


}
