using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionPoint : PointOfInterestWithQueue
{
    [SerializeField] private int checkTime = 5;
    [SerializeField] private List<Human> guards;

    private void Awake()
    {
        ListOfPoints.AddNewPoint(this, PointNames.InspectionPoint);
    }

    public override int GetRaitingPlace()
    {
        return GetLenQueue();
    }

    public override void Join(Passenger passenger)
    {
        passenger.SetActivity(HumanActivites.StayQueue);
        JoinQueue(passenger);
    }

    protected override void ChangePointOfInterest(Passenger passenger)
    {
        if (!passenger.CheckDocument())
        {
            Destroy(passenger);
            return;
        }
        passenger.ChoicePlace();
    }

    protected override float GetWaitingTime(Passenger passenger)
    {
        return checkTime + (100 - passenger.GetMood()) / 20;
    }
}
