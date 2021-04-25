using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraAtDistance : MonoBehaviour
{
    private Transform camera;
    public Transform AnchorObject;
    public float Distance;
    public float YDelta = 0;

    void Start()
    {
        camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(AnchorObject.position, camera.position, Distance);
        if (YDelta != 0)
        {
            transform.Translate(0, YDelta, 0);
        }
        transform.LookAt(transform.position + camera.forward);
    }
}