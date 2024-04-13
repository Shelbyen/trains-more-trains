using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointOfInterestWithQueue : PointOfInterest
{
    [SerializeField] private Vector2 directionQueue;
    private List<Passenger> peopleInQueue = new List<Passenger>();
    bool queueIsStart = false;

    public void JoinQueue(Passenger passenger)
    {
        peopleInQueue.Add(passenger);
        if (!queueIsStart)
        {
            StartCoroutine(MoveQueue());
        }
    }
    public Vector2 GetQueuePosition()
    {
        return new Vector2(transform.position.x + directionQueue.x * peopleInQueue.Count * 20, transform.position.y + directionQueue.y * peopleInQueue.Count * 20);
    }

    public int GetLenQueue() { return peopleInQueue.Count; }


    protected abstract void ChangePointOfInterest(Passenger passenger);

    IEnumerator MoveQueue()
    {
        queueIsStart = true;
        float progress = 0;
        while (progress <= GetWaitingTime(peopleInQueue[0]))
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.Scale();
        }

        ChangePointOfInterest(peopleInQueue[0]);
        peopleInQueue.RemoveAt(0);
        for (int i = 0; i < peopleInQueue.Count; i++)
        {
            peopleInQueue[i].Move(new Vector2(transform.position.x + directionQueue.x * i * 20, transform.position.y + directionQueue.y * i * 20));
        }
        if (peopleInQueue.Count != 0)
        {
            StartCoroutine(MoveQueue());
        } else
        {
            queueIsStart = false;
        }
    }

    protected abstract float GetWaitingTime(Passenger passenger);
}
