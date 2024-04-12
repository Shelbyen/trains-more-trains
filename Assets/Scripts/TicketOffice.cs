using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketOffice : PointOfInterestWithQueue
{
    [SerializeField] private int checkTime = 5;
    private void Awake()
    {
        ListOfPoints.AddNewPoint(gameObject, PointNames.TicketOffice);
    }

    protected override void ChangePointOfInterest(Passenger passenger)
    {
        passenger.ChoicePlace();
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

    public override int GetRaitingPlace()
    {
        return GetLenQueue();
    }

    public override void Join(Passenger passenger)
    {
        JoinQueue(passenger);
        passenger.SetActivity(HumanActivites.StayQueue);
    }
}
