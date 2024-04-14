using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketOffice : PointOfInterestWithQueue
{
    [SerializeField] private int checkTime = 5;
    private void Awake()
    {
        ListOfPoints.AddNewPoint(this, PointNames.TicketOffice);
    }

    protected override void ChangePointOfInterest(Passenger passenger)
    {
        passenger.ticket = true;
        passenger.ChoicePlace();
    }

    public override int GetRaitingPlace()
    {
        return GetLenQueue();
    }

    public override void Join(Passenger passenger)
    {
        JoinQueue(passenger);
        passenger.SetActivity(HumanActivites.StayQueue);
    }

    protected override float GetWaitingTime(Passenger passenger)
    {
        return checkTime + (100 - passenger.GetMood()) / 20;
    }
}
