using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBuilder : MonoBehaviour
{
    [SerializeField] private GameObject TrainPref;
    [SerializeField] private GameObject VanPref;
    private Dictionary<string, GameObject> flightList = new Dictionary<string, GameObject>();

    [SerializeField] private Transform[] beacons;
    [SerializeField] private float spawnDistance;

    public void CreateTrain(Flight flight)
    {
        if (!flight.isHere)
        {
            flight.isHere = true;
            GameObject train = Instantiate(TrainPref);
            train.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = flight.trainType;
            train.transform.position = new Vector2(spawnDistance, beacons[flight.line].position.y);
            train.GetComponent<Train>().stopPosition = beacons[flight.line];
            train.GetComponent<Train>().stopTime = flight.boardingTime;
            for (int l = 1; l <= flight.length; l += 1)
            {
                GameObject vanelement = Instantiate(VanPref, train.transform);
                vanelement.transform.localPosition = new Vector2(-8.4f * l, -0.1f);
                vanelement.GetComponent<SpriteRenderer>().sprite = flight.vanType;
            }
            flightList.Add(flight.flightName, train);
        }
        else
        {
            Destroy(flightList[flight.flightName]);
            flightList.Remove(flight.flightName);
        }
    }
}
