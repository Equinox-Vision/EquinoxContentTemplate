using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWorldYPosition : MonoBehaviour
{
     // Update is called once per frame
    void Update()
    {
        var p = gameObject.transform.position;
        gameObject.transform.position = new Vector3(p.x, -1.4f, p.z);
    }
}
