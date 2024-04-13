using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingTrain : PointOfInterest
{
    public override int GetRaitingPlace()
    {
        return 100;
    }

    public override void Join(Passenger passenger)
    {
        Destroy(passenger);
    }
}
