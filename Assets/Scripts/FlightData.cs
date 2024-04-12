using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlightData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ID;
    [SerializeField] private TextMeshProUGUI Date;
    [SerializeField] private TextMeshProUGUI Incoming;
    [SerializeField] private TextMeshProUGUI Outcoming;
    [SerializeField] private TextMeshProUGUI Van;
    [SerializeField] private Image VanIm;
    [SerializeField] private TextMeshProUGUI Train;
    [SerializeField] private Image TrainIm;

    private string trname;
    private FlightGenerator generator;

    private void Awake()
    {
       generator = FindObjectsOfType<FlightGenerator>()[0];
    }

    public void SetLine(TMP_Dropdown dropdown)
    {
        generator.SetLine(trname, dropdown.value);
    }

    public void SetData(Flight data, string train_name)
    {
        trname = train_name;
        ID.text = data.flightName;
        Date.text = TimeManager.TimeInstance().CalculateDate(data.date) + " " + TimeManager.TimeInstance().CalculateTime(data.arrivalTime) + "-" + TimeManager.TimeInstance().CalculateTime(data.arrivalTime + data.boardingTime);
        Incoming.text = "Посадка " + data.income;
        Outcoming.text = "Высадка " + data.outcome;
        Van.text = "Вагон х" + data.length;
        Train.text = data.trainType.name;
        TrainIm.sprite = data.trainType;
        VanIm.sprite = data.vanType;
    }
    //
}
