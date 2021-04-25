using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(new Vector3(Camera.main.transform.position.x, -EnvironmentEntityFacility.SpawnPlatformHeight, Camera.main.transform.position.z));
        //this.transform.LookAt(new Vector3(Camera.main.transform.position.x, gameObject.transform.position.y, Camera.main.transform.position.z));
        this.transform.LookAt(Camera.main.transform);
    }
}
