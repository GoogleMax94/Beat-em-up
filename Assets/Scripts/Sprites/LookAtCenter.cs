using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LookAtCenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x = transform.position.x > 0?-math.abs(scale.x): math.abs(scale.x);
        transform.localScale = scale;
    }
}
