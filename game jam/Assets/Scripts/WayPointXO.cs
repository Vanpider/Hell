using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Wave Config",fileName = "New Wave Config")]
public class WayPointXO : ScriptableObject
{
    [SerializeField] Transform path;
    [SerializeField] float speed = 5f;


    public Transform GetStartPath()
    {
        return path.GetChild(0);
    }



    public List<Transform> GetWayPoints()
    {

        List<Transform> wayPoints = new List<Transform>();
        foreach(Transform child in path)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
