using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlightGenerator : MonoBehaviour
{
    [SerializeField] private Dictionary<string, Flight> flightList = new Dictionary<string, Flight>();
    [SerializeField] private GameObject DataPref;
    [SerializeField] private Transform ScrollWindowParent;
    [SerializeField] private GameObject ObjectSpace;
    private int flightCount;
    [Header("������")]
    [SerializeField] private Sprite[] trainList;
    [SerializeField] private Sprite[] vanList;

    public void SetLine(string fl_name, int line)
    {
        flightList[fl_name].line = line;
    }

    public Flight GetFlight(string fl_name)
    {
        return flightList[fl_name];
    }

    public void GenerateNewFligh(int count, int from, int to)
    {
        for (int i = 0; i != count; i += 1)
        {
            string flight_name = ('0', 4 - flightCount.ToString().Length) + flightCount.ToString();
            int l = Random.Range(5, 10);
            int outcome = Random.Range(0, l * 5);
            int trainStyle = Random.Range(0, trainList.Length);
            flightList.Add( flight_name,
                    new Flight()
                    {
                        flightName = new string('0', 4 - flightCount.ToString().Length) + flightCount.ToString(),
                        type = Flight.flightType.passanger,
                        length = l,
                        outcome = outcome,
                        income = Random.Range(0, outcome + l * 3),
                        boardingTime = 60 + Random.Range(0, 30),
                        arrivalTime = (from + (to-from)/count*i + Random.Range(-6, 6)) * 10,
                        date = TimeManager.TimeInstance().GetDay(),
                        trainType = trainList[trainStyle],
                        vanType = vanList[trainStyle]
                    });
            GameObject newFD = Instantiate(DataPref);
            newFD.transform.SetParent(ObjectSpace.transform);
            newFD.transform.localPosition = new Vector3(250, 55 + 100 * flightCount);
            newFD.GetComponent<FlightData>().SetData(flightList[flight_name], flight_name);
            ObjectSpace.GetComponent<RectTransform>().sizeDelta = new Vector2(
                ObjectSpace.GetComponent<RectTransform>().sizeDelta.x,
                -110 -100 * flightCount);
            flightCount += 1;
        }
    }

    private void Awake()
    {
        GenerateNewFligh(5, 24, 132);
    }
}

[System.Serializable]
public class Flight
{
    public string flightName;
    public flightType type;
    public int outcome;
    public int income;
    public int date;
    public int arrivalTime;
    public int boardingTime;
    public int length;
    public Sprite trainType;
    public Sprite vanType;

    public int line;

    public enum flightType
    {
        passanger,
        cargo,
        coal,
        fuel
    }
}