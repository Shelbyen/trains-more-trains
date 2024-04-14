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
    public override Vector2 GetPosition(Passenger passenger)
    {
        for (int i = 0; i < peopleInQueue.Count; i++)
        {
            if (peopleInQueue[i] == passenger)
            {
                return new Vector2(transform.position.x + directionQueue.x * i * 2, transform.position.y + directionQueue.y * i * 2);
            }
        }
        return new Vector2(transform.position.x + directionQueue.x * peopleInQueue.Count * 2, transform.position.y + directionQueue.y * peopleInQueue.Count * 2);
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
            peopleInQueue[i].Move(new Vector2(transform.position.x + directionQueue.x * i * 2, transform.position.y + directionQueue.y * i * 2));
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
