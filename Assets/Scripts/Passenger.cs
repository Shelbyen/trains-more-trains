using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : Human
{
    [SerializeField] private string flight;
    [SerializeField] private bool documents;
    [SerializeField] private int mood;
    [SerializeField] private int folly;
    [SerializeField] private int luck;

    private void Awake()
    {
        
    }

    //если mood < 50 - идёт в киоск или кафе
    //folly отвечает за шанс совершить нарушение

    public int GetMood()
    {
        return mood;
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
}
