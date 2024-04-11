using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointOfInterest : MonoBehaviour
{
    [SerializeField] private Vector2 beginningQueue;
    [SerializeField] private Vector2 directionQueue;
    private List<Passenger> peopleInQueue;

    public Vector2 GetPlaceInQueue()
    { 
        return new Vector2(beginningQueue.x + directionQueue.x * peopleInQueue.Count, beginningQueue.y + directionQueue.y * peopleInQueue.Count); 
    }

    protected abstract void CheckPassenger(Passenger passenger);

    protected abstract void ChangePointOfInterest(Passenger passenger);
    
    void MoveQueue()
    {
        ChangePointOfInterest(peopleInQueue[0]);
        peopleInQueue.RemoveAt(0);
        for (int i = 0; i < peopleInQueue.Count; i++)
        {
            peopleInQueue[i].Move(new Vector2(beginningQueue.x + directionQueue.x * i, beginningQueue.y + directionQueue.y * i));
        }
        CheckPassenger(peopleInQueue[0]);
    }
}
