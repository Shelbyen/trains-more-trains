using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointOfInterest : MonoBehaviour
{
    public abstract int GetRaitingPlace();

    public abstract void Join(Passenger passenger);
}
