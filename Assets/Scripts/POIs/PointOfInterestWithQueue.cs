using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointOfInterestWithQueue : PointOfInterest
{
    [SerializeField] private Vector2 directionQueue;
    private List<Passenger> peopleInQueue = new List<Passenger>();

    public void JoinQueue(Passenger passenger)
    {
        peopleInQueue.Add(passenger);
        if (GetLenQueue() == 1)
        {
            MoveQueue();
        }
    }
    public Vector2 GetQueuePosition()
    {
        return new Vector2(transform.position.x + directionQueue.x * peopleInQueue.Count, transform.position.y + directionQueue.y * peopleInQueue.Count);
    }

    public int GetLenQueue() { return peopleInQueue.Count; }

    protected abstract void CheckPassenger(Passenger passenger);

    protected abstract void ChangePointOfInterest(Passenger passenger);

    protected void MoveQueue()
    {
        ChangePointOfInterest(peopleInQueue[0]);
        peopleInQueue.RemoveAt(0);
        for (int i = 0; i < peopleInQueue.Count; i++)
        {
            peopleInQueue[i].Move(new Vector2(transform.position.x + directionQueue.x * i, transform.position.y + directionQueue.y * i));
        }
        CheckPassenger(peopleInQueue[0]);
    }
}
