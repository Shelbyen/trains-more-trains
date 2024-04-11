using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketOffice : PointOfInterest
{
    [SerializeField] private int checkTime = 5;
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
        StartCoroutine(WaitChecking(passenger));
    }

    IEnumerator WaitChecking(Passenger passenger)
    {
        yield return new WaitForSeconds(checkTime + passenger.GetMood() / 20);
        MoveQueue();
    }
}
