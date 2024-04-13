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
        passenger.ticket = true;
        passenger.ChoicePlace();
    }

    protected override void CheckPassenger(Passenger passenger)
    {
        StartCoroutine(WaitChecking(passenger));
    }

    IEnumerator WaitChecking(Passenger passenger)
    {
        float progress = 0;
        while (progress <= checkTime + passenger.GetMood() / 20)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.Scale();
        }
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
