using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketOffice : PointOfInterest
{
    private void Awake()
    {
        ListOfPoints.AddNewPoint(gameObject, PointNames.TicketOffice);
    }

    protected override void ChangePointOfInterest(Passenger passenger)
    {
        passenger.SetTargetPlace(PointNames.WaitingRooms);
    }

    protected override void CheckPassenger(Passenger passenger)
    {
        return;
    }
}
