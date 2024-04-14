using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerGenerator : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject Pref;
    public FlightGenerator generator;

    private void Awake()
    {
        StartCoroutine(gener());
    }

    private IEnumerator gener()
    {
        float progress = 0;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            progress += Time.fixedDeltaTime / TimeManager.Scale();
            if (progress <= 2) { continue; }
            if (Random.Range(0, 10) == 1)
            {
                generator = GetComponent<FlightGenerator>();
                GameObject man = Instantiate(Pref, transform.parent);
                man.transform.position = spawnPos.position;
                Passenger passenger = man.GetComponent<Passenger>();
                passenger.SetTarget(PointNames.InspectionPoint);
                progress = 0;

            }
        }
    }
}
