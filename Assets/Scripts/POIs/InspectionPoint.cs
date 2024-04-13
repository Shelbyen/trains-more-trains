using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionPoint : PointOfInterestWithQueue
{
    [SerializeField] private int checkTime = 3;
    [SerializeField] private List<Human> guards;

    public override int GetRaitingPlace()
    {
        return GetLenQueue();
    }

    public override void Join(Passenger passenger)
    {
        JoinQueue(passenger);
        passenger.SetActivity(HumanActivites.StayQueue);
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
        return checkTime + (100 - passenger.GetMood()) / 10;
    }
}
