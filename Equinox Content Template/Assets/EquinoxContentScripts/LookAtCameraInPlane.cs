using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraInPlane : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var p = Camera.main.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
    }
}
