using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionPoint : PointOfInterest
{
    [SerializeField] private int checkTime = 3;
    [SerializeField] private List<Human> guards;
    protected override void ChangePointOfInterest(Passenger passenger)
    {
        if (!passenger.CheckDocument())
        {
            // Отправляем домой)
        }
        passenger.SetTargetPlace();
    }

    protected override void CheckPassenger(Passenger passenger)
    {
        StartCoroutine(WaitChecking(passenger));
    }

    IEnumerator WaitChecking(Passenger passenger)
    {
        yield return new WaitForSeconds(checkTime + passenger.GetMood() / 10);
    }
}
