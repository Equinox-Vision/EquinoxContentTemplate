using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBobAnimation : MonoBehaviour
{

    public float Amplitude = 0.5f;
    public float SpeedDivisor = 5;

    private float originalY;
    private float randomStart;

    // Start is called before the first frame update
    void Start()
    {
        originalY = gameObject.transform.position.y;
        randomStart = Random.Range(0, 2.0f*Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = gameObject.transform.position;
        pos.y = originalY + Mathf.Sin(Time.unscaledTime / SpeedDivisor + randomStart) * Amplitude;
        gameObject.transform.position = pos;
    }
}
