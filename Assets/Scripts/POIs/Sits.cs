using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sits : PointOfInterest
{
    [SerializeField] private List<Sit> sits;

    private void Awake()
    {
        sits = new List<Sit>();
        foreach (Transform trans in transform.GetComponentsInChildren<Transform>())
        {
            sits.Add(new Sit(trans, null));
        }
        ListOfPoints.AddNewPoint(this, PointNames.Sits);
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
            if (sits[i].Passenger == null)
            {
                clearSits.Add(i);
            }
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
                sits[i].ClearSit();
                return;
            }
        }

        List<int> clearSits = GetIdClearSits();
        if (clearSits.Count == 0)
        {
            passenger.SetMood(passenger.GetMood() - 20);
            passenger.ChoicePlace();
            return;
        }

        int idPassengerPlace = clearSits[Random.Range(0, clearSits.Count)];
        Sit sit = sits[idPassengerPlace];
        sit.Passenger = passenger;
        sits[idPassengerPlace] = sit;
        passenger.SetActivity(HumanActivites.Walk);

        passenger.SetTargetPlace(this);
        passenger.Move(sit.sitTransform.position);
    }

    public override Vector2 GetPosition(Passenger passenger)
    {
        foreach (Sit sit in sits)
        {
            if (sit.Passenger == passenger)
            {
                return new Vector2(sit.sitTransform.position.x, sit.sitTransform.position.y);
            }
        }

        return transform.position;
    }
}

struct Sit
{
    public Transform sitTransform { get; }
    public Passenger Passenger { get; set; }

    public Sit(Transform sitTransform, Passenger passenger)
    {
        this.sitTransform = sitTransform;
        this.Passenger = passenger;
    }

    public void ClearSit()
    {
        Passenger = null;
    }
}
