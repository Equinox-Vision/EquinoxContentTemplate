using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageBindToAspectRatioFitter : MonoBehaviour
{
    private AspectRatioFitter arf;
    private RawImage ri;

    // Start is called before the first frame update
    void Start()
    {
        arf = gameObject.GetComponent<AspectRatioFitter>();
        if (arf == null) {
            throw new System.Exception($"No AspectRatioFitter on component {this.name}");
        }
        ri = gameObject.GetComponent<RawImage>();
        if (ri == null) {
            throw new System.Exception($"No RawImage on component {this.name}");
        }

    }

    // Update is called once per frame
    // TODO: make an event to calculate the ratio only when the texture is changed
    void Update()
    {
        var ratio = (float)(ri.texture.width) / (float)(ri.texture.height);
        arf.aspectRatio = ratio;
    }
}
