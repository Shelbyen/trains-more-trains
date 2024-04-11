using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlightGenerator : MonoBehaviour
{
    [SerializeField] private List<Flight> flightList = new List<Flight>();
    private Dictionary<string, FlightData> targetLine = new Dictionary<string, FlightData>();
    [SerializeField] private GameObject DataPref;
    [SerializeField] private Transform ScrollWindowParent;
    [SerializeField] private GameObject ObjectSpace;
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
            GameObject newFD = Instantiate(DataPref);
            newFD.transform.SetParent(ObjectSpace.transform);
            newFD.transform.localPosition = new Vector3(250, 55 + 100 * flightCount);
            targetLine.Add(flightList[flightCount].flightName, newFD.GetComponent<FlightData>());
            ObjectSpace.GetComponent<RectTransform>().sizeDelta = new Vector2(ObjectSpace.GetComponent<RectTransform>().sizeDelta.x,-110 -100 * flightCount);
            flightCount += 1;
        }
    }

    private void Awake()
    {
        GenerateNewFligh(12);
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