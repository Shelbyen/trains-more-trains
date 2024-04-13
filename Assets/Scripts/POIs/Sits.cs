using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sits : PointOfInterest
{
    [SerializeField] private List<Sit> sits;

    private void Awake()
    {
        List<Sit> sits = new List<Sit>();
        foreach (Transform trans in transform.GetComponentsInChildren<Transform>())
        {
            sits.Add(new Sit(trans, null));
        }
        ListOfPoints.AddNewPoint(gameObject, PointNames.TicketOffice);
    }

    public override int GetRaitingPlace()
    {
        return sits.Count - GetIdClearSits().Count;
    }

    List<int> GetIdClearSits()
    {
        List<int> clearSits = new List<int>();
        for (int i = 0; i < sits.Count; i++)
        {
            if (sits[i].Passenger == null) clearSits[i] = i;
        }
        return clearSits;
    }

    public override void Join(Passenger passenger)
    {
        for (int i = 0; i < sits.Count;i++)
        {
            if (passenger == sits[i].Passenger)
            {
                passenger.SetActivity(HumanActivites.Sit);
                return;
            }
        }

        List<int> clearSits = GetIdClearSits();
        if (clearSits.Count == 0)
        {
            passenger.SetMood(passenger.GetMood() - 20);
            passenger.ChoicePlace();
        }

        int idPassengerPlace = clearSits[Random.Range(0, clearSits.Count)];
        Sit sit = sits[idPassengerPlace];
        sit.Passenger = passenger;
        sits[idPassengerPlace] = sit;
        passenger.SetActivity(HumanActivites.Walk);
        passenger.Move(sit.transform.position);
        passenger.SetTargetPlace(sit.transform.gameObject);
    }
}

struct Sit
{
    public Transform transform { get; }
    public Passenger Passenger { get; set; }

    public Sit(Transform transform, Passenger passenger)
    {
        this.transform = transform;
        this.Passenger = passenger;
    }
}
