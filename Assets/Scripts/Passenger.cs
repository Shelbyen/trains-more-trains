using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Passenger : Human
{
    [SerializeField] bool documents;
    [SerializeField] int mood;
    [SerializeField] int folly;
    [SerializeField] int luck;
    [SerializeField] bool noticed;
    bool inAction = false;

    [SerializeField] public bool ticket;
    [SerializeField] HumanActivites activity;

    private Flight flight;

    public void SetFlight(Flight data)
    {
        flight = data;
    }

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

    private new void FixedUpdate()
    {
        base.FixedUpdate();
        if (inAction) { return; }
        switch (activity)
        {
            case HumanActivites.Walk:
                Vector2 newPos = targetPlace.GetPosition(this);
                if (agent.pathEndPosition.x != newPos.x || agent.pathEndPosition.y != newPos.y)
                {
                    Move(newPos);
                }
                if (newPos.x - 0.3f < transform.position.x && transform.position.x < newPos.x + 0.3f)
                {
                    if (newPos.y - 0.3f < transform.position.y && transform.position.y < newPos.y + 0.3f)
                    {
                        targetPlace.Join(this);
                    }
                }
                return;

            case HumanActivites.Sit:
                StartCoroutine(Sit());
                return;
            case HumanActivites.Smoke:
                StartCoroutine(Smoke());
                return;
        }
    }

    public void ChoicePlace()
    {
        activity = HumanActivites.Walk;
        if (!ticket)
        {
            SetTarget(PointNames.TicketOffice);
            return;
        }

        if (mood > 80)
        {
            if (activity != HumanActivites.Sit)
            {
                SetTarget(PointNames.Sits);
            }
        } else if (mood >= 50)
        {
            if (activity != HumanActivites.Smoke)
            {
                SetTarget(PointNames.SmokePlace);
            }
            
        }
    }

    public bool CheckDocument()
    {
        return documents || (Random.Range(0, 100) < luck);
    }

    public void SetTarget(PointNames name)
    {
        List<PointOfInterest> places = ListOfPoints.GetAllPoints(name);
        if (places.Count == 0) return;

        int potencialPlace = 0;
        int minRaiting = places[0].GetRaitingPlace();
        for (int i = 0; i < places.Count; i++)
        {
            int raiting = places[i].GetRaitingPlace();
            if (minRaiting > raiting)
            {
                minRaiting = raiting;
                potencialPlace = i;
            }
        }

        targetPlace = places[potencialPlace];
        Move(targetPlace.GetPosition(this));
    }
    
    IEnumerator Sit()
    {
        inAction = true;
        float progress = 0;
        while (progress <= 100)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.Scale();
        }
        mood -= 10;
        ChoicePlace();
        inAction = false;
    }
    IEnumerator Smoke()
    {
        inAction = true;
        float progress = 0;
        while (progress <= 100)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.Scale();
        }
        mood += 10;
        ChoicePlace();
        inAction = false;
    }
}
