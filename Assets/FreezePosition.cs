using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FreezePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Hacky way to ensure this isn't accidentally moved
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}
