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

    protected override void CheckPassenger(Passenger passenger)
    {
        StartCoroutine(WaitChecking(passenger));
    }

    IEnumerator WaitChecking(Passenger passenger)
    {
        float progress = 0;
        while (progress <= checkTime + passenger.GetMood() / 10)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.TimeInstance().Scale();
        }
        MoveQueue();
    }
}
