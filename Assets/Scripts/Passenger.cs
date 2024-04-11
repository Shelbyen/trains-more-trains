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
        if (agent.isStopped && targetPlace != null)
        {
            targetPlace.GetComponent<PointOfInterest>().JoinQueue(this);
            targetPlace = null;
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

    public void SetTargetPlace(PointNames name)
    {
        List<GameObject> places = ListOfPoints.GetAllPoints(name);
        if (places.Count == 0)
        {
            return;
        }

        int potencialPlace = 0;
        int minimalQueue = 100;
        for (int i = 0; i < places.Count; i++)
        {
            int lenQueue = places[i].GetComponent<PointOfInterest>().GetLenQueue();
            if (minimalQueue > lenQueue)
            {
                minimalQueue = lenQueue;
                potencialPlace = i;
            }
        }
        targetPlace = places[potencialPlace];
    }
}
