using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotationAnimation : MonoBehaviour
{
    public float Speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(gameObject.transform.position, Vector3.up, Speed * Time.deltaTime);
    }
}
