using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterAWhile : MonoBehaviour
{
    public float Seconds = 1;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(deactivateAfterAWhile());
    }

    private IEnumerator deactivateAfterAWhile() {
        yield return new WaitForSecondsRealtime(Seconds);
        gameObject.SetActive(false);
    }

}
