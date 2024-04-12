using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class Passenger : Human
{
    [SerializeField] string flight;
    [SerializeField] bool documents;
    [SerializeField] int mood;
    [SerializeField] int folly;
    [SerializeField] int luck;
    [SerializeField] bool noticed;

    [SerializeField] bool ticket;
    [SerializeField] HumanActivites activity;
    [SerializeField] bool humanInActivity = false;

    //если mood < 50 - идёт в киоск или кафе
    //folly отвечает за шанс совершить нарушение

    public int GetMood()
    {
        return mood;
    }
    public void SetMood(int mood)
    {
        this.mood = mood;
    }

    public void SetActivity(HumanActivites activity) { this.activity = activity; }
    public bool GetNoticed() { return noticed; }
    public void SetNoticed(bool newNoticed) { noticed = newNoticed; }

    private void FixedUpdate()
    {
        if (activity == HumanActivites.Walk && agent.isStopped)
        {
            targetPlace.GetComponent<PointOfInterest>().Join(this);
            targetPlace = null;
            humanInActivity = true;
        }

        if (humanInActivity)
        {
            return;
        }

        switch (activity)
        {
            case HumanActivites.Walk:
                return;
            case HumanActivites.Sit:
                return; // Корутина на анимацию
            case HumanActivites.Smoke:
                return; // Корутина на анимацию
            // И так далее хехехе
        }
    }

    public void ChoicePlace()
    {
        activity = HumanActivites.Walk;
        if (!ticket)
        {
            SetTargetPlace(PointNames.TicketOffice);
            return;
        }
        if (mood > 80)
        {
            SetTargetPlace(PointNames.Sits);
            return;
        }
        if (mood >= 50)
        {
            SetTargetPlace(PointNames.SmokePlace);
        } else if (mood >= 70)
        {

        }
    }

    public bool CheckDocument()
    {
        return documents || (Random.Range(0, 100) < luck);
    }

    public void SetTargetPlace(PointNames name)
    {
        List<GameObject> places = ListOfPoints.GetAllPoints(name);
        if (places.Count == 0) return;

        int potencialPlace = 0;
        int minRaiting = 0;
        for (int i = 0; i < places.Count; i++)
        {
            int raiting = places[i].GetComponent<PointOfInterest>().GetRaitingPlace();
            if (minRaiting > raiting)
            {
                minRaiting = raiting;
                potencialPlace = i;
            }
        }

        targetPlace = places[potencialPlace];
        Move(targetPlace.transform.position);
    }
}
