using System;
using UnityEngine;

public class SmokePlace : PointOfInterest
{
    [SerializeField] Vector2[] actionZone;

    private void Awake()
    {
        ListOfPoints.AddNewPoint(this, PointNames.SmokePlace);
    }
    public override Vector2 GetPosition(Passenger passenger)
    {
        return new Vector2(UnityEngine.Random.Range(actionZone[0].x, actionZone[1].x), UnityEngine.Random.Range(actionZone[0].y, actionZone[1].y));
    }

    public override int GetRaitingPlace()
    {
        return 1;
    }

    public override void Join(Passenger passenger)
    {
        passenger.SetActivity(HumanActivites.Smoke);
    }
}
