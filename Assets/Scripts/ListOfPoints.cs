using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListOfPoints
{
    private static Dictionary<PointNames, List<PointOfInterest>> allPoints = new();

    public static void AddNewPoint(PointOfInterest pointOfInterest, PointNames name)
    {
        if (!allPoints.ContainsKey(name))
        {
            allPoints.Add(name, new List<PointOfInterest>());
        }
        allPoints[name].Add(pointOfInterest);
    }

    public static List<PointOfInterest> GetAllPoints(PointNames name)
    {
        return allPoints[name];
    }
}
