using UnityEngine;
using System.Collections.Generic;

public class GodThreadDrawer : MonoBehaviour
{
    public LineRenderer line;
    public Transform hand;

    private List<Vector3> points = new List<Vector3>();

    void Start()
    {
        line.positionCount = 0;
    }

    void Update()
    {
        Vector3 pos = hand.position;

        if(points.Count == 0 || Vector3.Distance(points[points.Count-1], pos) > 0.05f)
        {
            points.Add(pos);

            line.positionCount = points.Count;
            line.SetPositions(points.ToArray());
        }
    }
}