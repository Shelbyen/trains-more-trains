using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
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
        switch (activity)
        {
            case HumanActivites.Walk:
                if (targetPlace.transform.position.x - 0.5f < transform.position.x && transform.position.x < targetPlace.transform.position.x + 0.5f)
                {
                    if (targetPlace.transform.position.y - 0.5f < transform.position.y && transform.position.y < targetPlace.transform.position.y + 0.5f)
                    {
                        targetPlace.GetComponent<PointOfInterest>().Join(this);
                    }
                }
                return;

            case HumanActivites.Sit:
                StartCoroutine(Sit());
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
            SetTarget(PointNames.Sits);
            return;
        }
        if (mood >= 50)
        {
            SetTarget(PointNames.SmokePlace);
        } else if (mood >= 70)
        {

        }
    }

    public bool CheckDocument()
    {
        return documents || (Random.Range(0, 100) < luck);
    }

    public void SetTarget(PointNames name)
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
    
    IEnumerator Sit()
    {
        float progress = 0;
        while (progress <= 100)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.TimeInstance().Scale();
        }
        
        ChoicePlace();
    }
}
