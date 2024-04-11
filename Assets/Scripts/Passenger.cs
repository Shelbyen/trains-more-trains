using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Passenger : Human
{
    [SerializeField] private string flight;
    [SerializeField] private bool documents;
    [SerializeField] private int mood;
    [SerializeField] private int folly;
    [SerializeField] private int luck;
    bool inQueue = false;

    //если mood < 50 - идёт в киоск или кафе
    //folly отвечает за шанс совершить нарушение

    public int GetMood()
    {
        return mood;
    }

    private void Update()
    {
        if (inQueue)
        {
            return;
        }
        if (agent.isStopped)
        {
            targetPlace.GetComponent<PointOfInterest>().JoinQueue(this);
            inQueue = true;
            return;
        }
    }

    public bool CheckDocument()
    {
        if (documents)
        {
            return true;
        } else {
            if (Random.Range(0, 100) < luck)
            {
                return true;
            } else {
                return false;
            }
        }
    }

    public void SetTargetPlace()
    {
        throw new System.NotImplementedException();
    }
}
