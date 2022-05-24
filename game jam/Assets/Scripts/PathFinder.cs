using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPointXO waveConfig;

    List<Transform> wayPoints;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }


    void FollowPath()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPos = wayPoints[wayPointIndex].position;

            float delta = waveConfig.GetSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, delta);


            if(transform.position == targetPos)
            {
                wayPointIndex++;
            }

        }
        else
        {
            wayPointIndex = 0;
        }
    }
}
