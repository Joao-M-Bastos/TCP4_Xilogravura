using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{

    public GameObject quad;
    public MeshRenderer quadMash;

    private float meshSize, scale;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(quadMash.bounds.size.x * transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            quad.transform.position -= new Vector3(0, 0, quadMash.bounds.size.x * transform.localScale.x) ;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            quad.transform.position += new Vector3(quadMash.bounds.size.x * transform.localScale.x, 0, 0);
        }

    }
}
