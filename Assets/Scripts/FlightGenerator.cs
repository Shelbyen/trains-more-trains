using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightGenerator : MonoBehaviour
{
    [SerializeField] private List<Flight> flightList = new List<Flight>();
    [SerializeField] private Dictionary<string, int> targetLine = new Dictionary<string, int>();
    private int flightCount; 

    public void GenerateNewFligh(int count)
    {
        for (int i = 0; i != count; i += 1)
        {
            int l = Random.Range(5, 10);
            int outcome = Random.Range(0, l * 15);
            flightList.Add(new Flight() {
                flightName = new string('0', 4 - flightCount.ToString().Length) + flightCount.ToString(),
                type = Flight.flightType.passanger,
                length = l,
                outcome = outcome,
                income = Random.Range(0, outcome + l * 5),
                arrivalTime = 30 + Random.Range(0, 15),
            });
            targetLine.Add(flightList[flightCount].flightName, 0);
            flightCount += 1;
        }
    }

    private void Awake()
    {
        GenerateNewFligh(3);
    }
}

[System.Serializable]
public struct Flight
{
    public string flightName;
    public flightType type;
    public int outcome;
    public int income;
    public int date;
    public int arrivalTime;
    public int boardingTime;
    public int length;

    public void SetLength(int x)
    {
        length = x; 
    }


    public enum flightType
    {
        passanger,
        cargo,
        coal,
        fuel
    }
}