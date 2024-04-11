using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListOfPoints
{
    private static Dictionary<PointNames, List<PointOfInterest>> allPoints = new Dictionary<PointNames, List<PointOfInterest>>();

    static ListOfPoints()
    {
        allPoints.Clear();
        allPoints[PointNames.InspectionPoint] = new List<PointOfInterest>();
        allPoints[PointNames.WaitingRoom] = new List<PointOfInterest>();
    }

    public static void AddNewPoint(PointOfInterest pointOfInterest, PointNames name)
    {
        allPoints[name].Add(pointOfInterest);
    }
}
