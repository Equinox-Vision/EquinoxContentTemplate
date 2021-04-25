using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public float Speed = 0.05f;
    public float StoppingDistance = 0.1f;
    public List<GameObject> WayPoints;
    public bool RandomStart = true;
    private int currentWayPointIndex = 0;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        if (RandomStart)
        {
            currentWayPointIndex = (int)Random.Range(0, WayPoints.Count);
            if (currentWayPointIndex >= WayPoints.Count)
            {
                currentWayPointIndex = WayPoints.Count - 1;
            }
            Speed *= Random.Range(0.9f, 1.1f);
        }
        direction = Vector3.Normalize(WayPoints[currentWayPointIndex].transform.position - gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (WayPoints.Count == 0)
        {
            return;
        }
        gameObject.transform.LookAt(WayPoints[currentWayPointIndex].transform);

        gameObject.transform.position = gameObject.transform.position + direction * Speed;

        var distance = Vector3.Distance(WayPoints[currentWayPointIndex].transform.position, gameObject.transform.position);
        if (distance < StoppingDistance)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= WayPoints.Count)
            {
                currentWayPointIndex = 0;
            }
            direction = Vector3.Normalize(WayPoints[currentWayPointIndex].transform.position - gameObject.transform.position);
        }
    }
}
