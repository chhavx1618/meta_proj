using UnityEngine;
using System.Collections.Generic;

public class ThreadGenerator : MonoBehaviour
{
    public LineRenderer line;
    public List<Transform> points;

    void Start()
    {
        line.positionCount = points.Count;

        for(int i=0;i<points.Count;i++)
        {
            line.SetPosition(i, points[i].position);
        }
    }
}