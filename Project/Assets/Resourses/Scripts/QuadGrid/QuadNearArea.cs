using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadNearArea : MonoBehaviour
{
    SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = this.gameObject.GetComponent<SphereCollider>();
    }

    
}
