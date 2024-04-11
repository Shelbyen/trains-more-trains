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
    [SerializeField] private TextMeshProUGUI Train;

    public void SetData(string id, string date, int incoming, int outcoming, int length)
    {
        ID.text = id;
        Date.text = date;
        Incoming.text = "Посадка " + incoming;
        Outcoming.text = "Высадка " + outcoming;
        Van.text = "Вагон х" + length;
        Train.text = "ГТ1h";
    }
}
