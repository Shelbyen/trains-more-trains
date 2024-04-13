using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListOfPoints
{
    private static Dictionary<PointNames, List<GameObject>> allPoints = new();

    public static void AddNewPoint(GameObject pointOfInterest, PointNames name)
    {
        if (!allPoints.ContainsKey(name))
        {
            allPoints.Add(name, new List<GameObject>());
        }
        allPoints[name].Add(pointOfInterest);
    }

    public static List<GameObject> GetAllPoints(PointNames name)
    {
        return allPoints[name];
    }
}
